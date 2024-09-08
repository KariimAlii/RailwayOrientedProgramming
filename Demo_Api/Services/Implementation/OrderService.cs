using Demo_Api.Controllers;

namespace Demo_Api.Services
{
    public class OrderService : IOrderService
    {
        public int Submit(int transactionId, List<LineItem> lineItems)
        {
            if (lineItems.Count > 2)
            {
                throw new ArgumentException("Invalid Line Items");
            }
            else if (lineItems.Count == 3)
            {
                return 3;
            }
            return 0;
        }
    }
}
