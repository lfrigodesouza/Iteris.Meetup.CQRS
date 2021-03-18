using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class ToggleProductActivationCommand : IRequest<Response>
    {
        public int ProductId { get; set; }
    }
}