namespace FlightLogNet.Models
{
    public class PersonModel
    {
        public required long MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressModel Address { get; set; }
    }
}
