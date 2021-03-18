using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string Nome { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}