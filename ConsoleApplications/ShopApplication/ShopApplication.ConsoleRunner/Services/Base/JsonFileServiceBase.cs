using Newtonsoft.Json;

namespace ShopApplication.ConsoleRunner.Services.Base
{
    public abstract class JsonFileServiceBase<T>
    {
        private string _filePath;

        public JsonFileServiceBase(string filePath)
        {
            _filePath = filePath;
        }

        public void Write(List<T> tags)
        {
            var textData = JsonConvert.SerializeObject(tags);
            File.WriteAllText(_filePath, textData);
        }

        public List<T> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }

            var textData = File.ReadAllText(this._filePath);
            var tags = JsonConvert.DeserializeObject<List<T>>(textData);

            return tags;
        }
    }
}
