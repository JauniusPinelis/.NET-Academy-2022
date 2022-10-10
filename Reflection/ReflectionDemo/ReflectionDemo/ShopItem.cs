using System.ComponentModel;

namespace ReflectionDemo
{
    public class ShopItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public override string ToString()
        {
            var result = "";
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                result += $"{name}: {value}\n";
            }

            return result;
        }
    }
}
