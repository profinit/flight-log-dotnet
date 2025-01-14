namespace FlightLogNet.Models
{
    using System;

    public class FlightLandingModel
    {
        public required long FlightId { get; set; }

        public required DateTime LandingTime { get; set; }
    }
}
