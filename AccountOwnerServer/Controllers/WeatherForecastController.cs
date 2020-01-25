using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountOwner.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};
        private IRepositoryWrapper RepoWrapper;
        private readonly ILoggerManager Logger;

        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            RepoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IList<string> Get()
        {
            IList<string> methodReturn = new List<string>();
            var domesticAccounts = RepoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = RepoWrapper.Owner.FindAll();
            foreach (var owner in owners)
            {
                methodReturn.Add(owner.Name);
            }
            return methodReturn;
        }

        //public WeatherForecastController(ILoggerManager logger)
        //{
        //    Logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{            
        //    Logger.LogInfo("Here is info message from the controller.");
        //    Logger.LogDebug("Here is debug message from the controller.");
        //    Logger.LogWarn("Here is warn message from the controller.");
        //    Logger.LogError("Here is error message from the controller.");

        //var rng = new Random();

        //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = DateTime.Now.AddDays(index),
        //    TemperatureC = rng.Next(-20, 55),
        //    Summary = Summaries[rng.Next(Summaries.Length)]
        //})
        //.ToArray();
        //}
    }
}
