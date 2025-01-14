﻿namespace FlightLogNet.Models
{
    using System;

    public class FlightTakeOffModel
    {
        public required DateTime TakeoffTime { get; set; }

        public string Task { get; set; }

        public AirplaneWithCrewModel Towplane { get; set; }

        public AirplaneWithCrewModel Glider { get; set; }
    }
}
