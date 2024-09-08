using Demo_Api.Controllers;

namespace Demo_Api.Services
{
    public interface IStockService
    {
        bool IsEnoughStock(List<LineItem> items);
        void UpdateInventory(List<LineItem> items);
    }
}
