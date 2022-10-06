namespace EFCoreWebApi.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? GroupEntityId { get; set; }
    }
}
