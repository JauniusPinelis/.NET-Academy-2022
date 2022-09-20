using ConsoleApp.Project.Models;
using Newtonsoft.Json;

namespace ConsoleApp.Project.Services
{
    public class FileJsonService
    {
        private readonly string _fileName = "ItemData.txt";

        public void Write(List<Item> items)
        {
            string jsonData = JsonConvert.SerializeObject(items);

            File.WriteAllText(_fileName, jsonData);
        }

        public List<Item> Import()
        {
            var textData = File.ReadAllText(_fileName);

            var items = JsonConvert.DeserializeObject<List<Item>>(textData);

            return items;
        }
    }
}
