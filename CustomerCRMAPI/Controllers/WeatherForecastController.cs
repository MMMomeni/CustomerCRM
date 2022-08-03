using Microsoft.AspNetCore.Mvc;

namespace CustomerCRMAPI.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Welcome to Web API";
        }
        [HttpGet("GetByNameCity")]
        public IActionResult Get( string city, string name)
        {
            string result = "method with query string";
            return Ok(result);
        }

        //[HttpGet("GetByNameCity")]
        //public IActionResult Get(string name)
        //{
        //    return "Welcome " + name;
        //}


        
        //[HttpGet]
        //[Route("GetById/{id}")]
        //public IActionResult GetById(int id)
        //{

        //}

        [HttpPost]
        public IActionResult Post([FromBody] int id)
        {
            return Ok(new {id,});
        }

    }
}