using KubernetesTestApi;
using Prometheus;
using Serilog;
using Serilog.Sinks.Loki;

var credentials = new NoAuthCredentials("http://localhost:3100");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.LokiHttp(credentials)
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<ApiKeyRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpMetrics();


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapMetrics();
app.UseMetricServer();

app.Run();
