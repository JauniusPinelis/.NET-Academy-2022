namespace FirstWebApi.Dtos
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedUtc { get; set; } = null;
    }
}
