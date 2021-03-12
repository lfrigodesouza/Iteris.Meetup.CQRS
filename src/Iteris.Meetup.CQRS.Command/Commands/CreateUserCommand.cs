using Iteris.Meetup.Domain.Entities;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Nome { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}