using System;
using Iteris.Meetup.CQRS.Domain.Enums;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Notifications
{
    public class UserChangedNotification : INotification
    {
        public UserChangedNotification(int userId, ChangeTypeEnum type)
        {
            UserId = userId;
            Type = type;
            DtChanged = DateTime.Now;
        }

        public int UserId { get; set; }
        public ChangeTypeEnum Type { get; }
        public DateTime DtChanged { get; set; }
    }
}
