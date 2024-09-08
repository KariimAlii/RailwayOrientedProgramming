namespace Demo_Api.Controllers
{
    public class SubmitOrderRequest
    {
        public List<LineItem> LineItems { get; set; }
        public int CreditCardId { get; set; }
        public double TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
    public class LineItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
}