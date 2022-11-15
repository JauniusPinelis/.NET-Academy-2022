using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SquareManagement.Core.Interfaces;
using SquareManagement.Repositories.Repositories;

namespace SquareManagement.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddTransient((sp) => new NpgsqlConnection(connectionString));

            services.AddTransient<IPointListRepository, PointListRepository>();

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
    }
}
