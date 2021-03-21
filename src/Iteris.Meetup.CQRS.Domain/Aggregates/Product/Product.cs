using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.Product
{
    public class Product
    {
        private Product()
        {
        }

        public static Product DefaultEntity() => new Product();


        public Product(string name, bool active)
        {
            Name = name;
            Active = active;
        }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
