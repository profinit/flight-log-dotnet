namespace FlightLogNet.Repositories.Entities
{
    using Models;

    public class Airplane
    {
        public long Id { get; set; }

        public ClubAirplane ClubAirplane { get; set; }

        public string GuestAirplaneImmatriculation { get; set; }

        public string GuestAirplaneType { get; set; }

        public AirplaneModel ToModel() => new()
        {
            Id = Id,
            Immatriculation = ClubAirplane != null
                ? ClubAirplane.Immatriculation
                : GuestAirplaneImmatriculation,
            Type = ClubAirplane != null
                ? ClubAirplane.AirplaneType.Type
                : GuestAirplaneType,
        };
    }
}