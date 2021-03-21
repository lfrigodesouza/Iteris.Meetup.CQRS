using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Notifications
{
    public class NewAddressNotification : INotification
    {
        public NewAddressNotification(int userId, int addressId)
        {
            UserId = userId;
            AddressId = addressId;
            DtCreated = DateTime.Now;
        }
        public int UserId { get; set; }
        public DateTime DtCreated { get; set; }
        public int AddressId { get; set; }
    }
}
