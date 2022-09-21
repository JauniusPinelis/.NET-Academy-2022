using ShopApplication.ConsoleRunner.Models;
using ShopApplication.ConsoleRunner.Services.Base;

namespace ShopApplication.ConsoleRunner.Services
{
    public class ItemFileService : JsonFileServiceBase<Item>
    {
        public ItemFileService() : base("fileData.txt")
        {

        }
    }
}
