using System;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Enums;
using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Application.Commands.AddSubscription
{
    public class AddSubscriptionCommand : IRequest<Response>
    {
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public int SubscriptionType { get; set; }
        public DateTime DtStart { get; set; }
    }
}