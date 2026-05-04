namespace FlightLogNet.Operation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FlightLogNet.Models;
    using Repositories.Interfaces;

    public class GetExportToCsvOperation(IFlightRepository flightRepository)
    {
        public byte[] Execute()
        {
            var report = flightRepository.GetReport();
            var sb = new StringBuilder();
            var flatReport = report
                .SelectMany(r => new List<FlightModel> { r.Towplane, r.Glider })
                .ToList();

            sb.AppendLine("Datum,Typ,Imatrikulace,Osádka,Úkol,Start,Přistání,Doba letu");

            foreach (var item in flatReport)
            {
                string Escape(string? value)
                {
                    if (string.IsNullOrEmpty(value))
                        return "";

                    if (value.Contains(",") || value.Contains("\""))
                        return $"\"{value.Replace("\"", "\"\"")}\"";

                    return value;
                }
                if (item != null)
                {
                    System.TimeSpan? diff = null;
                    if (item.LandingTime != null)
                    {
                        diff = item.LandingTime - item.TakeoffTime;
                    }

                    sb.AppendLine(string.Join(",",
                        item.TakeoffTime.ToString("dd. MM. yyyy"),
                        Escape(item.Airplane.Type),
                        Escape(item.Airplane.Immatriculation),
                        Escape(item.Pilot.LastName),
                        Escape(item.Task),
                        item.TakeoffTime.ToString("HH:mm:ss"),
                        item.LandingTime?.ToString("HH:mm:ss"),
                        (diff == null) ? "" : $"{(int)diff.Value.TotalHours}°{diff.Value.Minutes}'"
                    ));
                }
            }

            var resultText = sb.ToString();
            return Encoding.UTF8.GetBytes(resultText);
        }
    }
}
