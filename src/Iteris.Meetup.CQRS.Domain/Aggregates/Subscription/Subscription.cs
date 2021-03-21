using Iteris.Meetup.CQRS.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.Subscription
{
    public class Subscription : Entity
    {
        private Subscription()
        {

        }

        public static Subscription DefaultEntity() => new Subscription();

        public Subscription(string customerId, int productId, SubscriptionType subscriptionType)
        {
            CustomerId = customerId;
            CourseId = courseId;
            AddDomainEvent(new ProductSubscribedEvent(this));
        }

        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

    }
}
