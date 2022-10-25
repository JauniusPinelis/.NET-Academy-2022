using Microsoft.AspNetCore.Identity;

namespace StaffManagement.WebApi.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? DateOfBirth { get; set; }
    }
}
