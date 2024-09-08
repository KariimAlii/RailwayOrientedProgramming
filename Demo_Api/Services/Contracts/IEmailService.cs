namespace Demo_Api.Services
{
    public interface IEmailService
    {
        void SendOrderConfirmation(int customerId, int orderId);
    }
}
