namespace MyApp.Models
{
    public class Item
    {
        private int _itemId;
        private string _itemName;

        public int ItemId
        {
            get => _itemId;
            set => _itemId = value;
        }

        public string ItemName
        {
            get => _itemName;
            set => _itemName = value;
        }
    }
}