using Iteris.Meetup.CQRS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.Customer
{
    public class Customer : Entity
    {
        private Customer()
        {
        }

        public static Customer DefaultEntity() => new Customer();

        public Customer(string customerId, Email email)
        {
            CustomerId = customerId;
            Email = email;
            AddDomainEvent(new NewCustomerCreatedEvent(this));
        }

        public string CustomerId { get; }
        public string Name { get; set; }
        public Email Email { get; }
        public DateTime BirthDate { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
        public DateTime UpdatedAt { get; private set; }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year;

                if (DateTime.Now.DayOfYear < BirthDate.DayOfYear)
                    age--;

                return age;
            }
        }

    }
}
