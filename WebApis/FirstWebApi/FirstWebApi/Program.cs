using FirstWebApi.ApiClients;
using FirstWebApi.Repositories;
using FirstWebApi.Services;

namespace FirstWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add(Register) services to the container.
            // Transient, Scoped, Singleton -> lifetimes
            builder.Services.AddTransient<PersonService>();
            builder.Services.AddTransient<PersonRepository>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddApiClients();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}