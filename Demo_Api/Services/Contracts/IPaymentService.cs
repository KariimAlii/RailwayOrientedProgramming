namespace Demo_Api.Services
{
    public interface IPaymentService
    {
        string ChargeCreditCard(int CreditCardId, double TotalAmount);
    }
}
