using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress
{
    public class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommand, Response>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateUserAddressCommandHandler> _logger;
        private readonly IMediator _mediator;

        public CreateUserAddressCommandHandler(ILogger<CreateUserAddressCommandHandler> logger,
            IMediator mediator,
            IAddressRepository addressRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _addressRepository = addressRepository;
        }

        public async Task<Response> Handle(CreateUserAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var address = new Address(request.UserId, request.StreetName, request.StreetNumber, request.Complement,
                    request.Cep, request.City, request.State, request.Name);
                await _addressRepository.Create(address);

                await _mediator.Publish(address.DomainEvents, cancellationToken);

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