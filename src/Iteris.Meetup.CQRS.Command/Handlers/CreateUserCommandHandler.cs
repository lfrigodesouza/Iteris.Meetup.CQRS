using System;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Entities;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}