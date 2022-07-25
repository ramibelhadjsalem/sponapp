using Microsoft.AspNetCore.Mvc;
using sponapp.Data;
using sponapp.DTOs;
using sponapp.Entities;

namespace sponapp.Controllers
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
        private readonly IUnitOfWork unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Task<IList<FoodItem>> get()
        {
            _logger.LogInformation(this.unitOfWork.recips.Count().ToString()  );
            return  unitOfWork.foods.GetAll();
        }
    }
}