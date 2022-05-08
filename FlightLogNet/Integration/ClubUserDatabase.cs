namespace FlightLogNet.Integration
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FlightLogNet.Models;

    using Microsoft.Extensions.Configuration;

    using RestSharp;

    public class ClubUserDatabase : IClubUserDatabase
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public ClubUserDatabase(IConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;
        }

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

        private IList<ClubUser> ReceiveClubUsers()
        {
            var client = new RestClient(configuration["ClubUsersApi"]);
            var request = new RestRequest("club/user", DataFormat.Json);

            var response = client.Get<List<ClubUser>>(request);

            return response.Data;
        }

        private IList<PersonModel> TransformToPersonModel(IList<ClubUser> users)
        {
            return this.mapper.ProjectTo<PersonModel>(users.AsQueryable()).ToList();
        }
    }
}
