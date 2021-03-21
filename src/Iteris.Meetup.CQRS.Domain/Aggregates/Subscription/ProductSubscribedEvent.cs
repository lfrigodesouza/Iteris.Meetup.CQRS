using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.Subscription
{
    public class ProductSubscribedEvent : INotification
    {
        public ProductSubscribedEvent(Subscription subscription)
        {
            Subscription = subscription;
        }

        public Subscription Subscription { get; }
    }
}
}
