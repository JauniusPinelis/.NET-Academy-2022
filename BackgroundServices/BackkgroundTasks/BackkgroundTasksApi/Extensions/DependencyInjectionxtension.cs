using BackkgroundTasksApi.BackgroundServices;
using BackkgroundTasksApi.Repositories;
using BackkgroundTasksApi.Settings;

namespace BackkgroundTasksApi.Extensions
{
    public static class DependencyInjectionxtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<TimedBackgroundHostedService>();
            services.AddScoped<TestRepository>();

            services.Configure<BackgroundServiceSettings>(configuration.GetSection("BackgroundServices"));
        }
    }
}
