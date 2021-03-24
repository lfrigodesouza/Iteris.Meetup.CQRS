using System;
using MediatR;

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