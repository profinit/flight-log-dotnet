namespace FlightLogNet.Models
{
    public class AirplaneModel
    {
        public required long Id { get; set; }

        public required string Immatriculation { get; set; }

        public required string Type { get; set; }
    }
}
