using ConsoleApp.Project.Models;

namespace ConsoleApp.Project.Services
{
    public class FileTextService
    {
        private readonly string _fileName = "ItemData.txt";
        public void Write(List<Item> items)
        {
            string fileData = "";

            foreach (var item in items)
            {
                fileData += item.ToString() + "\n";
            }

            File.WriteAllText(_fileName, fileData);
        }

        public List<Item> Import()
        {
            List<Item> items = new();
            var fileData = File.ReadAllLines(_fileName);

            foreach (var item in fileData)
            {
                var parsedData = item.Split(" ");
                items.Add(new Item
                {
                    Name = parsedData[1],
                    Quantity = int.Parse(parsedData[3])
                });
            }

            return items;
        }
    }
}
