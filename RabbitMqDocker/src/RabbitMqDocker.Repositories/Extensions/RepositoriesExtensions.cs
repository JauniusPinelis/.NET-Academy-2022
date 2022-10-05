using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace RabbitMqDocker.Repositories.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient((sp) => new NpgsqlConnection("Server=postgres;Port=5432;Database=tasks_db;User Id=postgres;Password=password;"));
            services.AddTransient<TaskRepository>();
        }
    }
}
