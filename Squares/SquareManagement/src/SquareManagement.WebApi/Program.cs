using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SquareManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
{
    Type = SecuritySchemeType.OAuth2,
    Flows = new OpenApiOAuthFlows()
    {
        Implicit = new OpenApiOAuthFlow()
        {
            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
            TokenUrl = new Uri("https://localhost:5001/connect/authorize"),
            Scopes = new Dictionary<string, string>
            {
                //{ "api://29a02307-5a1b-460c-85ba-9e9abb75e48d/Read.WeatherForecast", "Reads the Weather forecast" }
            }
        }
    }
}));

builder.Services.ConfigureServices(builder.Configuration);

builder.Services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = "https://localhost:5001";

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false,
               };
           });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "admin");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
