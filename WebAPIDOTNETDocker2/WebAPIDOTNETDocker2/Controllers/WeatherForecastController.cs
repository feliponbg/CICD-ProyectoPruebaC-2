using Microsoft.AspNetCore.Mvc;

namespace WebAPIDOTNETDocker2.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast", Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogError("Mandando error de prueba al LOG");
            Response.Headers.Add("X-Header-Personalizado", "Bonjour");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetWeatherForecast2", Name = "GetWeatherForecast2")]
        public async Task<IActionResult> Get2()
        {
            _logger.LogError("Mandando error de prueba al LOG");
            Response.Headers.Add("X-Header-Personalizado", "Bonjour 2");

            await Task.Delay(100);

            return Ok(new { error = false, message = "Tr?s bien!" });
        }
    }
}