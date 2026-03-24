namespace FlightLogNet.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Entities;
    using Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class AirplaneRepository(IConfiguration configuration) : IAirplaneRepository
    {
        public long AddGuestAirplane(AirplaneModel airplaneModel)
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            Airplane airplane = new Airplane
            {
                GuestAirplaneImmatriculation = airplaneModel.Immatriculation,
                GuestAirplaneType = airplaneModel.Type,
            };

            dbContext.Airplanes.Add(airplane);
            dbContext.SaveChanges();
            return airplane.Id;
        }

        public IList<AirplaneModel> GetClubAirplanes()
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            var airplanes = dbContext.ClubAirplanes
                .Include(airplane => airplane.AirplaneType);

            return airplanes.Select(a => a.ToModel()).ToList();
        }

        public bool TryGetAirplane(AirplaneModel airplaneModel, out long airplaneId)
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            var firstAirplane = dbContext.Airplanes.FirstOrDefault(airplane => airplane.Id == airplaneModel.Id);
            if (firstAirplane != null)
            {
                airplaneId = firstAirplane.Id;
                return true;
            }
            else
            {
                airplaneId = 0;
                return false;
            }
        }
    }
}
