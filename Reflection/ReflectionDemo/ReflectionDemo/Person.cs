using System.ComponentModel;

namespace ReflectionDemo
{
    public class Person
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; } = false;

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
