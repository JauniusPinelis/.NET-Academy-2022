using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StaffManagement.Repositories;
using StaffManagement.Repositories.Entities;
using StaffManagement.Services.Configurations;
using StaffManagement.Services.Services;
using System.Text;

namespace StaffManagement.WebApi
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureServices(configuration)
                .ConfigureInfrastructure(configuration)
                .ConfigureAuthentication(configuration)
                .ConfigureCors();
        }

        // Builder pattern

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                                  policy =>
                                  {
                                      policy.AllowAnyHeader().AllowAnyOrigin();
                                  });
            });

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("jwt"));

            services.AddTransient<JwtService>();
            services.AddTransient<ApiKeyService>();

            return services;
        }

        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
           .AddEntityFrameworkStores<DataContext>()
           .AddDefaultTokenProviders();

            var defaultConnection = configuration.GetConnectionString("Default");

            services.AddDbContext<DataContext>(x => x.UseNpgsql(defaultConnection));

            return services;
        }

        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.RequireHttpsMetadata = false;

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("jwt:Secretkey"))),
                       ValidateIssuerSigningKey = false,
                       ValidateAudience = false,
                       ValidateIssuer = false,
                   };
               });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User",
                      policy => policy.RequireClaim("User"));
                options.AddPolicy("Admin",
                     policy => policy.RequireClaim("Roles", "Admin"));
            });

            return services;
        }
    }
}
