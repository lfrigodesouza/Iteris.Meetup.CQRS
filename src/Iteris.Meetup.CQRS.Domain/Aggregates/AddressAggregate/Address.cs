using Iteris.Meetup.CQRS.Domain.SeedWorks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate
{
    public class Address : Entity
    {
        public Address()
        {
        }

        public Address(int userId,
            string streetName,
            int streetNumber,
            string complement,
            string cep,
            string city,
            string state,
            string name)
        {
            UserId = userId;
            StreetName = streetName;
            StreetNumber = streetNumber;
            Complement = complement;
            Cep = cep;
            City = city;
            State = state;
            Name = name;
            AddDomainEvent(new AddressCreatedEvent(this));
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}