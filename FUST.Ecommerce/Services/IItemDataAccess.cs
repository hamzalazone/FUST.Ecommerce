using Fust.Ecommerce.Models;

namespace Fust.Ecommerce.Services
{
    public interface IItemDataAccess
    {
        void AddItem(Item item);
        void DeleteItem(int Id);
        Item? GetItem(int Id);
        IEnumerable<Item> GetItems();
        void UpdateItem(Item item);
        void UpdateToFalse(Item item);
        void UpdateToTrue(Item item);


    }
}