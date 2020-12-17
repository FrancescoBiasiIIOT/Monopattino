using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Monopattino.Server.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetectionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DetectionController> _logger;

        public DetectionController(ILogger<DetectionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            throw new NotImplementedException();
        }
    }
}
