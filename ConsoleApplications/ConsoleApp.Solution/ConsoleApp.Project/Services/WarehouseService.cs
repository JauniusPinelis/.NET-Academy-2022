using ConsoleApp.Project.Models;

namespace ConsoleApp.Project.Services
{
    public class WarehouseService
    {
        private List<Item> _items = new List<Item>();

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
