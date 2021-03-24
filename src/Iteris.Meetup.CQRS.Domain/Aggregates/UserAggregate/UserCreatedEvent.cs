using System;
using MediatR;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate
{
    public class UserCreatedEvent : INotification
    {
        public UserCreatedEvent(User user)
        {
            User = user;
            DtChanged = DateTime.Now;
        }

        public User User { get; set; }
        public DateTime DtChanged { get; set; }
    }
}