using System.Collections;
using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.Services
{
    public interface IItemsService
    {
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
    }
}