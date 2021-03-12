using System;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Enums;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class AddUserSubscriptionCommand
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int SubscriptionType { get; set; }
        public DateTime DtStart { get; set; }
    }
}