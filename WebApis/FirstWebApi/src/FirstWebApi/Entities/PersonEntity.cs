namespace FirstWebApi.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedUtc { get; set; } = null;

        public bool IsDeleted { get; set; } = false;
    }
}
