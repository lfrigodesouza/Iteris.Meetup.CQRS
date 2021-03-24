using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUser
{
    public class AddressCreatedEventEmailHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<AddressCreatedEventEmailHandler> _logger;

        public AddressCreatedEventEmailHandler(ILogger<AddressCreatedEventEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UserID: {notification.User.Id} | DtChanged: {notification.DtChanged}");

            _logger.LogInformation("Seu cadastro foi realizado com sucesso!");

            return Task.CompletedTask;
        }
    }
}