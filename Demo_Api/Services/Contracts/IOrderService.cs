using Demo_Api.Controllers;

namespace Demo_Api.Services
{
    public interface IOrderService
    {
        int Submit(string transactionId, List<LineItem> lineItems);
    }
}
