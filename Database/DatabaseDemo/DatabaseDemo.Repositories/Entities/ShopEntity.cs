namespace DatabaseDemo.Repositories.Entities
{
    public class ShopEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ShopItemEntity> ShopItems { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
