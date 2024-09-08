using Demo_Api.Controllers;

namespace Demo_Api.Services
{
    public class StockService : IStockService
    {
        private List<LineItem> _inventory = new List<LineItem>();
        public bool IsEnoughStock(List<LineItem> items)
        {
            return items.Count > 2;
        }

        public void UpdateInventory(List<LineItem> items)
        {
            _inventory.AddRange(items);
        }
    }
}
