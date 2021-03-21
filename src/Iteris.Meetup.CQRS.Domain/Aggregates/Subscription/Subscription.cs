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

        public Subscription(string customerId, int courseId)
        {
            CustomerId = customerId;
            CourseId = courseId;
            AddDomainEvent(new ProductSubscribedEvent(this));
        }

        public string CustomerId { get; set; }
        public int CourseId { get; set; }

    }
}
