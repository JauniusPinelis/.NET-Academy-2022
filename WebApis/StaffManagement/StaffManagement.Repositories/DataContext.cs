using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffManagement.Repositories.Entities;

namespace StaffManagement.Repositories
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserApiKey> ApiKeys { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
