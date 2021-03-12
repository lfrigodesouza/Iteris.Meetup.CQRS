using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Command.Handlers
{
    public class AddedSubscriptionPushNotificationHandler : INotificationHandler<AddedSubscriptionNotification>
    {
        private readonly ILogger<AddedSubscriptionPushNotificationHandler> _logger;

        public AddedSubscriptionPushNotificationHandler(ILogger<AddedSubscriptionPushNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AddedSubscriptionNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Enviando notification para serviço de e-mail");
            return Task.CompletedTask;
        }
    }
}