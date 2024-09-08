namespace Demo_Api.Services
{
    public class PaymentService : IPaymentService
    {
        public int ChargeCreditCard(int CreditCardId, double TotalAmount)
        {
            if (TotalAmount > 5000)
                throw new Exception("Amount not accepted");

            return 0;
        }
    }
}
