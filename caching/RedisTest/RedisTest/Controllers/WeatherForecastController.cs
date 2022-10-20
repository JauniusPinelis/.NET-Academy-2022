using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace RedisTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDistributedCache _cache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("cache/{id}")]
        public async Task<IActionResult> GetCache(string id)
        {
            var result = await _cache.GetAsync(id);
            if (result == null)
            {
                var jsonContent = JsonConvert.SerializeObject(id);
                var byteContent = Encoding.UTF8.GetBytes(jsonContent);

                var distributedCacheOptions = new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddDays(1),
                    SlidingExpiration = TimeSpan.FromHours(1),
                };

                await _cache.SetAsync(id, byteContent, distributedCacheOptions);

                return NotFound();
            }

            var serializedData = Encoding.UTF8.GetString(result);
            return Ok(JsonConvert.DeserializeObject<string>(serializedData));
        }
    }
}