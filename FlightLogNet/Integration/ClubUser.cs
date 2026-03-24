namespace FlightLogNet.Integration
{
    using System.Collections.Generic;

    using Models;

    public class ClubUser
    {
        public long MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<string> Roles { get; set; }

        public PersonModel ToPersonModel() => new()
        {
            MemberId = MemberId,
            FirstName = FirstName,
            LastName = LastName,
        };
    }
}
