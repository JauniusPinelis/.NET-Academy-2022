namespace StaffManagement.Repositories.Entities
{
    public class UserApiKey
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
