using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalLibrary.Api.Helper;
using PersonalLibrary.BusinessModels;

namespace PersonalLibrary.Api.Controllers
{
    /// <summary>
    /// Sample constructor for weather forecast mock
    /// </summary>
    [Produces(OutputProducts.Json)]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Route(Route.Value)]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Weather forecast controller constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Mock GET weather forecast
        /// </summary>
        /// <returns>Mock random weather</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {          
            var rng = new Random();
            _logger.LogInformation("TestLogging.");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
