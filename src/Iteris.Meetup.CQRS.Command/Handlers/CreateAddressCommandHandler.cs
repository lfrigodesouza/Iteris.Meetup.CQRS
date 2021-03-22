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
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Response>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateAddressCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateAddressCommandHandler(ILogger<CreateAddressCommandHandler> logger,
            IMediator mediator,
            IAddressRepository addressRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _addressRepository = addressRepository;
        }

        public async Task<Response> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address(request.UserId, request.StreetName, request.StreetNumber, request.Complement,
                    request.Cep, request.City, request.State, request.Name);
                var addressId = await _addressRepository.Create(address);

                var notification = new UserChangedNotification(request.UserId, ChangeTypeEnum.UpdatedItem);
                await _mediator.Publish(notification, cancellationToken);

                _logger.LogInformation("Endereço cadastrado com sucesso");
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
