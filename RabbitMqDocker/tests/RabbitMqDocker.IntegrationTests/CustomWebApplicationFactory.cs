using MassTransit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Linq;

namespace RabbitMqDocker.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Mass Transit
                var massTransitHostedService = services.FirstOrDefault(d => d.ServiceType == typeof(IBus));

                services.Remove(massTransitHostedService);
                var descriptors = services.Where(d =>
                       d.ServiceType.Namespace.Contains("MassTransit", StringComparison.OrdinalIgnoreCase))
                                          .ToList();
                foreach (var d in descriptors)
                {
                    services.Remove(d);
                }

                services.AddMassTransit(x =>
                {
                    x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                    {
                        config.Host("localhost", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });
                    }));
                });

                // 
                var npgsqlConnection = services.FirstOrDefault(d => d.ServiceType == typeof(NpgsqlConnection));

                services.Remove(npgsqlConnection);

                services.AddTransient((sp) => new NpgsqlConnection("Server=localhost;Port=5432;Database=tasks_db;User Id=postgres;Password=password;"));
            });
        }
    }
}
