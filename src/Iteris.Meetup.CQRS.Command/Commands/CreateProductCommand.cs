using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class CreateProductCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public int[] AcceptedSubscriptionTypes { get; set; }
    }
}