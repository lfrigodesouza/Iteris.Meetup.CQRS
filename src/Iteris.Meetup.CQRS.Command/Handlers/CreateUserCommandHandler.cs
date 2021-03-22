using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.CQRS.Command.Notifications;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Enums;
using Iteris.Meetup.Domain.Interfaces.Repositories;
using Iteris.Meetup.Domain.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Command.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateUserCommand> _logger;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ILogger<CreateUserCommand> logger,
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

                var address = new Address(userId, request.StreetName, request.StreetNumber, request.Complement,
                    request.Cep, request.City, request.State, request.StreetName);
                await _addressRepository.Create(address);

                var notification = new UserChangedNotification(userId, ChangeTypeEnum.NewItem);
                await _mediator.Publish(notification, cancellationToken);

                _logger.LogInformation("Usuário cadastrado com sucesso");
                return Response.Ok(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar usuário");
                return Response.Fail(HttpStatusCode.InternalServerError, "Erro ao cadastrar usuário");
            }
        }
    }
}
