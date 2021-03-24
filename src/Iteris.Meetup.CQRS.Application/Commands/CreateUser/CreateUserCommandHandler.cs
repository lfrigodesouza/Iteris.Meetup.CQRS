using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.CrossCutting;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            IMediator mediator)
        {
            _logger = logger;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _mediator = mediator;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newUser = new User(request.Name, request.Surname, request.Birthday, request.Cpf);
                var userId = await _userRepository.Create(newUser);

                await _mediator.Dispatch(newUser.DomainEvents, cancellationToken);

                var address = new Address(userId, request.StreetName, request.StreetNumber, request.Complement,
                    request.Cep, request.City, request.State, request.AddressName);
                await _addressRepository.Create(address);

                await _mediator.Dispatch(address.DomainEvents, cancellationToken);

                return Response.Ok(HttpStatusCode.Created, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar usuário");
                return Response.Fail(HttpStatusCode.InternalServerError, "Erro ao cadastrar usuário");
            }
        }
    }
}