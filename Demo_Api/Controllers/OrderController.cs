using Demo_Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Demo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IStockService _stockService;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;

        public OrderController(IOrderService orderService, IStockService stockService, IPaymentService paymentService, IEmailService emailService)
        {
            _orderService = orderService;
            _stockService = stockService;
            _paymentService = paymentService;
            _emailService = emailService;
        }
        [HttpPost("submit")]
        public IResult Submit_Refactor(SubmitOrderRequest request)
        {
            return ValidateLineItems(request)
                .Bind(_ => ValidateStock(request))
                .TryCatch(_ => _paymentService.ChargeCreditCard(request.CreditCardId, request.TotalAmount), Error.PaymentFailed)
                .Bind(transactionId => SubmitOrder(transactionId, request.LineItems))
                .Tap(_ => _stockService.UpdateInventory(request.LineItems))
                .Tap(o => _emailService.SendOrderConfirmation(request.CustomerId, o.OrderId))
                .Match
                (
                    o => Results.Ok(ApiResponse<OrderCreatedResponse>.CreateSuccess(new OrderCreatedResponse(o.OrderId, o.TransactionId))),
                    err => err.Type switch
                    {
                        ErrorType.Validation => Results.BadRequest(err.Description),
                        _ => Results.StatusCode(StatusCodes.Status500InternalServerError)
                    }
                );


        }

        // 🚩 1 input ➡️ 2 output
        Result<SubmitOrderRequest> ValidateLineItems(SubmitOrderRequest request)
        {
            return request.LineItems.Any()
                ? Result<SubmitOrderRequest>.Success(request)
                : Result<SubmitOrderRequest>.Failure(Error.NoLineItems);
        }
        // 🚩 1 input ➡️ 2 output
        Result<SubmitOrderRequest> ValidateStock(SubmitOrderRequest request)
        {
            return _stockService.IsEnoughStock(request.LineItems)
                ? Result<SubmitOrderRequest>.Success(request)
                : Result<SubmitOrderRequest>.Failure(Error.NotEnoughStock);
        }
        // 🚩 1 input ➡️ 2 output
        Result<(int OrderId, string TransactionId)> SubmitOrder(string transactionId, List<LineItem> lineItems)
        {
            var orderId = _orderService.Submit(transactionId, lineItems);
            return Result<(int OrderId, string TransactionId)>.Success((orderId, transactionId));
        }
       
        [HttpPost("submit")]
        public IResult Submit(SubmitOrderRequest request)
        {
            if (!request.LineItems.Any())
                return Results.BadRequest("Line Items are empty");

            if (!_stockService.IsEnoughStock(request.LineItems))
                return Results.BadRequest("Not Enough Stock for order");

            string transactionId;

            try
            {
                transactionId = _paymentService.ChargeCreditCard(request.CreditCardId, request.TotalAmount);
            }
            catch (Exception ex)
            {

                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }

            var orderId = _orderService.Submit(transactionId, request.LineItems);

            // 🚩 Product Side Effect & don't return any value ( Command )
            _stockService.UpdateInventory(request.LineItems);
            // 🚩 Product Side Effect & don't return any value ( Command )
            _emailService.SendOrderConfirmation(request.CustomerId, orderId);

            return Results.Ok(ApiResponse<OrderCreatedResponse>.CreateSuccess(new OrderCreatedResponse(orderId, transactionId)));
        }
    }
}
