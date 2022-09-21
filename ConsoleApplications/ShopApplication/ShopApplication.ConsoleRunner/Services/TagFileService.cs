using ShopApplication.ConsoleRunner.Models;
using ShopApplication.ConsoleRunner.Services.Base;

namespace ShopApplication.ConsoleRunner.Services
{
    public class TagFileService : JsonFileServiceBase<Tag>
    {
        public TagFileService() : base("tagsData.txt")
        {

        }
    }
}
