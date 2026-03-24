namespace FlightLogNet.Repositories.Entities
{
    using Models;

    public class Person
    {
        public long Id { get; set; }

        public PersonType PersonType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address Address { get; set; }

        public long MemberId { get; set; }

        public PersonModel ToModel() => new()
        {
            MemberId = MemberId,
            FirstName = FirstName,
            LastName = LastName,
            Address = Address?.ToModel(),
        };
    }
}