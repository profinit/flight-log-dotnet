namespace FlightLogNet.Repositories.Entities
{
    using Models;

    public class Address
    {
        public long Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public AddressModel ToModel() => new()
        {
            Street = Street,
            City = City,
            PostalCode = PostalCode,
            Country = Country,
        };
    }
}
