namespace FlightLogNet.Controllers
{
    using System.Collections.Generic;

    using FlightLogNet.Facades;
    using FlightLogNet.Models;

    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class AirplaneController : ControllerBase
    {
        private readonly ILogger<AirplaneController> logger;
        private readonly AirplaneFacade airplaneFacade;

        public AirplaneController(ILogger<AirplaneController> logger, AirplaneFacade airplaneFacade)
        {
            this.logger = logger;
            this.airplaneFacade = airplaneFacade;
        }

        [HttpGet]
        public IEnumerable<AirplaneModel> GetClubAirplanes()
        {
            this.logger.LogDebug("Get club airplanes.");
            return this.airplaneFacade.GetClubAirplanes();
        }
    }
}
