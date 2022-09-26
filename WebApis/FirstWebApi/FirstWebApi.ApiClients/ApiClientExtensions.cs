using Microsoft.Extensions.DependencyInjection;

namespace FirstWebApi.ApiClients
{
    public static class ApiClientExtensions
    {
        public static void AddApiClients(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<JsonPlaceholderApiClient>();
        }
    }
}
