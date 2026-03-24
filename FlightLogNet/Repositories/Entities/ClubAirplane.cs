namespace FlightLogNet.Repositories.Entities
{
    using Models;

    public class ClubAirplane
    {
        public long Id { get; set; }

        public string Immatriculation { get; internal set; }

        public AirplaneType AirplaneType { get; internal set; }

        public bool Archive { get; set; }

        public AirplaneModel ToModel() => new()
        {
            Id = Id,
            Immatriculation = Immatriculation,
            Type = AirplaneType.Type,
        };
    }
}