namespace FlightLogNet.Operation
{
    using System.Text;
    using System.Collections.Generic;
    using System.Globalization;

    using FlightLogNet.Models;
    using FlightLogNet.Repositories.Interfaces;

    public class GetExportToCsvOperation
    {
        private readonly IFlightRepository flightRepository;

        public GetExportToCsvOperation(IFlightRepository flightRepository)
        {
            this.flightRepository = flightRepository;
        }

        public byte[] Execute()
        {
            // TODO 5.1: Naimplementujte export do CSV
            // TIP: CSV soubor je pouze string, který se dá vytvořit pomocí třídy StringBuilder
            // TIP: Do bytové reprezentace je možné jej převést například pomocí metody: Encoding.UTF8.GetBytes(..)
//            string csv =
//@"FlightId,TakeoffTime,LandingTime,Immatriculation,Type,Pilot,Copilot,Task,TowplaneID,GliderID
//444,07.01.2020 16:47:10,07.01.2020 17:17:10,OK-B123,L-13A Blaník,Lenka Kiasová, ,Tahac,444,
//1,02.01.2020 16:47:10,,OK-V23424,Zlín Z-42M,Lenka Kiasová, ,VLEK,4,1
//4,02.01.2020 16:47:10,,OK-B123,L-13A Blaník,Silvie Hronová, ,Tahac,4,1
//24057,02.01.2020 15:17:10,,OK-V23424,Zlín Z-42M,Petr Hrubec, ,VLEK,24058,24057
//24058,02.01.2020 15:17:10,,OK-B123,L-13A Blaník,Silvie Hronová, ,Tahac,24058,24057
//";

//            return Encoding.UTF8.GetBytes(csv);
            var csv = new StringBuilder();

            // var reports = this.flightRepository.GetReport();

            csv.AppendLine(
                "FlightId,TakeoffTime,LandingTime,Immatriculation,Type,Pilot,Copilot,Task,TowplaneID,GliderID");

            foreach (var report in this.flightRepository.GetAllFlights(null))
            {
                csv.AppendLine(
                    $"{report.Id},{report.TakeoffTime},{report.LandingTime},{report.Airplane.Immatriculation},{report.Airplane.Type},{report.Pilot},{report.Copilot},{report.Task}");
            }
            // var newLine = $"{0},{1}";

            // File.WriteAllText(filePath, csv.ToString());
            return Encoding.UTF8
                .GetBytes(csv.ToString());

        }
    }
}
