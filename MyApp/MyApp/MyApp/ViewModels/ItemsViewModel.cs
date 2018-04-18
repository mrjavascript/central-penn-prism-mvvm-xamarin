using System.Collections.Generic;
using System.Windows.Input;
using MyApp.Models;
using MyApp.Services;
using MyApp.Services.Impl;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyApp.ViewModels
{
    public class ItemsViewModel : BindableBase
    {
        private readonly IItemsService _itemsService;
        private IEnumerable<Item> _items;
        private string _itemName;

        public string ItemName
        {
            get => _itemName;
            set => SetProperty(ref _itemName, value);
        }

        public ICommand GoBackCommand { get; set; }
        public ICommand AddItemCommand { get; set; }

        public IEnumerable<Item> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ItemsViewModel(INavigationService navigationService, IItemsService itemsService)
        {
            _itemsService = itemsService;
            Items = _itemsService.GetItems();

            GoBackCommand = new DelegateCommand(
                async () => await navigationService.GoBackAsync()
            );

            AddItemCommand = new DelegateCommand(
                () => _itemsService.AddItem(new Item {ItemId = 555, ItemName = ItemName})
            );
        }
    }
}