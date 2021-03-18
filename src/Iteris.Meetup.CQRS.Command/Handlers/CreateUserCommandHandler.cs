using System;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Command.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Response.Ok();
        }
    }
}