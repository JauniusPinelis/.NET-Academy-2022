using KubernetesTestApi.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace KubernetesTestApi.Controllers
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
        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [ApiKey]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(DateTime date)
        {
            var convertedDate = date.Date.ToString();
            _memoryCache.TryGetValue(convertedDate, out object cacheResult);

            if (cacheResult != null)
            {
                var cacheData = JsonConvert.DeserializeObject<List<WeatherForecast>>(cacheResult.ToString());
                return cacheData;
            }

            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _memoryCache.Set(convertedDate, JsonConvert.SerializeObject(data));

            return data;
        }
    }
}