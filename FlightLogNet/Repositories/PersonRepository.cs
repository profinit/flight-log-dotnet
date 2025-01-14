namespace FlightLogNet.Repositories
{
    using System.Linq;

    using Models;
    using Entities;
    using Interfaces;

    using Microsoft.Extensions.Configuration;

    public class PersonRepository(IConfiguration configuration) : IPersonRepository
    {
        public long AddGuestPerson(PersonModel person)
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            var address = new Address { City = person.Address.City, Country = person.Address.Country, PostalCode = person.Address.PostalCode, Street = person.Address.Street };
            var personEntity = new Person { Address = address, FirstName = person.FirstName, LastName = person.LastName, PersonType = PersonType.Guest };

            dbContext.Persons.Add(personEntity);
            dbContext.SaveChanges();

            return personEntity.Id;
        }

        public long CreateClubMember(PersonModel pilot)
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            var person = new Person
            {
                FirstName = pilot.FirstName,
                LastName = pilot.LastName,
                PersonType = PersonType.ClubMember,
                MemberId = pilot.MemberId,
            };

            dbContext.Persons.Add(person);
            dbContext.SaveChanges();

            return person.Id;
        }

        public bool TryGetPerson(PersonModel personModel, out long personId)
        {
            using var dbContext = new LocalDatabaseContext(configuration);

            Person firstPerson = dbContext.Persons.FirstOrDefault(person => person.MemberId == personModel.MemberId);
            if (firstPerson != null)
            {
                personId = firstPerson.Id;
                return true;
            }
            else
            {
                personId = 0;
                return false;
            }
        }
    }
}
