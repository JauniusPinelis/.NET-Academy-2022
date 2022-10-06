using EFCoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }
    }
}
