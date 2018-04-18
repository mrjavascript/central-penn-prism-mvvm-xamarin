using System.Collections.Generic;
using System.Net.NetworkInformation;
using MyApp.Models;

namespace MyApp.Services.Impl
{
    public class ItemsService : IItemsService
    {
        private readonly List<Item> _items;

        public ItemsService()
        {
            _items = new List<Item>
            {
                new Item {ItemId = 1, ItemName = "First Item"},
                new Item {ItemId = 2, ItemName = "Second Item"},
                new Item {ItemId = 3, ItemName = "Third Item"}
            };
        }

        public IEnumerable<Item> GetItems()
        {
            return _items;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }
    }
}