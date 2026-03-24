namespace FlightLogNet.Repositories.Entities
{
    using System.ComponentModel.DataAnnotations;

    using Models;

    public class FlightStart
    {
        public long Id { get; set; }

        [Required]
        public Flight Towplane { get; set; }

        public Flight Glider { get; set; }

        public ReportModel ToModel() => new()
        {
            Towplane = Towplane?.ToModel(),
            Glider = Glider?.ToModel(),
        };
    }
}
