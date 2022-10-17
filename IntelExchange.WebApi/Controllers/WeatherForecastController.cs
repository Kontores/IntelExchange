using Microsoft.AspNetCore.Mvc;

namespace IntelExchange.WebApi.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger)
        {
        }

        [HttpGet]
        [Route("getweather")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-5, 5),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}