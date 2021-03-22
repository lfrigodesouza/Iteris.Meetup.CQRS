using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.Domain.Entities
{
    public class UserAddress
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
