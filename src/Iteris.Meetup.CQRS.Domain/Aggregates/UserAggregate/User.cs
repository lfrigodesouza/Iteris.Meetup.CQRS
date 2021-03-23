using Iteris.Meetup.CQRS.Domain.SeedWorks;
using System;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate
{
    public class User : Entity
    {
        //TODO - add email? change cpf to document?
        public User(string name, string surname, DateTime birthday, string cpf)
        {
            Cpf = cpf;
            Name = name;
            Surname = surname;
            Birthday = new DateTime(birthday.Year, birthday.Month, birthday.Day);
            AddDomainEvent(new UserCreatedEvent(this));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Cpf { get; set; }
    }
}