using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteris.Meetup.Domain.Enums;

namespace Iteris.Meetup.Domain.Entities
{
    public class Product
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public SubscriptionType[] SubscriptionTypes { get; set; }
    }
}
