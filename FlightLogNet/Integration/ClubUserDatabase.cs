namespace FlightLogNet.Integration
{
    using System.Collections.Generic;
    using System.Linq;

    using Models;

    using Microsoft.Extensions.Configuration;

    using RestSharp;

    public class ClubUserDatabase(IConfiguration configuration) : IClubUserDatabase
    {
        // TODO 8.1: Přidejte si / použijte přes dependency injection configuraci

        private string baseUrl = configuration["ClubUsersApi"];


        public bool TryGetClubUser(long memberId, out PersonModel personModel)
        {
            personModel = this.GetClubUsers().FirstOrDefault(person => person.MemberId == memberId);

            return personModel != null;
        }

        public IList<PersonModel> GetClubUsers()
        {
            IList<ClubUser> x = this.ReceiveClubUsers();
            return this.TransformToPersonModel(x);
        }

        private List<ClubUser> ReceiveClubUsers()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("club/user");
            var response = client.Get<List<ClubUser>>(request);
            return response;
        }

        private List<PersonModel> TransformToPersonModel(IList<ClubUser> users)
        {
            return null;
        }
    }
}
