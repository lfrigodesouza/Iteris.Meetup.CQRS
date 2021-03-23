using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress
{
    public class AddressCreatedEventEmailHandler : INotificationHandler<AddressCreatedEvent>
    {
        private readonly ILogger<AddressCreatedEventEmailHandler> _logger;

        public AddressCreatedEventEmailHandler(ILogger<AddressCreatedEventEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AddressCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                $"UserID: {notification.Address.UserId} | DtChanged: {notification.DtChanged}");

            _logger.LogInformation(
                "Usuário, um novo endereço foi cadastrado na sua conta. Se não foi você, clique aqui e verifique suas informações.");

            return Task.CompletedTask;
        }
    }
}