using DatabaseDemo.Repositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace DatabaseDemo.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddTransient((sp) => new NpgsqlConnection(connectionString));

            services.AddTransient<ShopItemRepository>();
            services.AddTransient<ShopRepository>();
            services.AddTransient<TagRepository>();
        }
    }
}
