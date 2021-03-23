using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate
{
    public class AddressCreatedEvent : INotification
    {
        public AddressCreatedEvent(Address address)
        {
            Address = address;
            DtChanged = DateTime.Now;
        }

        public Address Address { get; set; }
        public DateTime DtChanged { get; set; }
    }
}
