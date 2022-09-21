using ShopApplication.ConsoleRunner.Models.Base;

namespace ShopApplication.ConsoleRunner.Models
{
    public class Item : NamedEntity
    {
        public DateTime ExpiryDate { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
