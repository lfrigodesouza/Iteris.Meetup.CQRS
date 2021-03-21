using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.Domain.Entities;
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
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ILogger<CreateUserCommand> logger, IUserRepository userRepository,
            IAddressRepository addressRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
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

                _logger.LogInformation("Usuário cadastrado com sucesso");
                return Response.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar usuário");
                return Response.Fail(HttpStatusCode.InternalServerError, "Erro ao cadastrar usuário");
            }
        }
    }
}