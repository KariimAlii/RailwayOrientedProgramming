namespace Demo_Api.Services
{
    public class EmailService : IEmailService
    {
        public void SendOrderConfirmation(int customerId, int orderId)
        {
            if (orderId == 0 || customerId == 0)
                throw new InvalidOperationException("Customer or Order Id is not valid");

            // send email logic
        }
    }
}
