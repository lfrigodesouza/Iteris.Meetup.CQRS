using MediatR;
using System.Collections.Generic;

namespace Iteris.Meetup.CQRS.Domain.SeedWorks
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents() => _domainEvents?.Clear();
    }
}