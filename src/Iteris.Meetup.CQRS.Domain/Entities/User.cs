using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
