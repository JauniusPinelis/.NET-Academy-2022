using Microsoft.AspNetCore.Identity;

namespace StaffManagement.Repositories.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateOfBirth { get; set; }
    }
}
