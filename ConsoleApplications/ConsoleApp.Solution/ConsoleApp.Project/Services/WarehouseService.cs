using ConsoleApp.Project.Models;

namespace ConsoleApp.Project.Services
{
    public class WarehouseService
    {
        private List<Item> _items;
        private FileJsonService _fileTextService;

        public WarehouseService()
        {
            _fileTextService = new FileJsonService();
            _items = _fileTextService.Import();
        }

        public void Add(string itemName)
        {
            var selectedItem = GetOne(itemName);

            if (selectedItem != null)
            {
                selectedItem.Quantity++;
            }
            else
            {
                _items.Add(new Item
                {
                    Name = itemName,
                });
            }

            _fileTextService.Write(_items);
        }

        private Item GetOne(string itemName)
        {
            return _items.FirstOrDefault(item => item.Name.Equals(itemName));
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public void Remove(string itemName)
        {
            Item selectedItem = GetOne(itemName);

            if (selectedItem != null)
            {
                if (selectedItem.Quantity == 1)
                {
                    _items.Remove(selectedItem);
                }
                else
                {
                    selectedItem.Quantity--;
                }
            }
            else
            {
                throw new ArgumentException("Item was not found");
            }
        }
    }
}
