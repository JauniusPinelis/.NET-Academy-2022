using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SquareManagement.Repositories.Extensions;
using SquareManagement.Services.Services;

namespace SquareManagement.Services
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddRepositories(configuration);

            services.AddTransient<PointListService>();
        }
    }
}
