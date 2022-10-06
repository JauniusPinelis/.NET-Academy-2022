namespace EFCoreWebApi.Entities
{
    public class GroupEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TaskEntity> Tasks { get; set; }
    }
}
