using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmployeeServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repo;
        public WeatherForecastController(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<string> Get()
        {
            //var projects = _repo.ProjectRepo.FindAll();
            return new string[] { "value 1", "value 2" };
        }
    }
}