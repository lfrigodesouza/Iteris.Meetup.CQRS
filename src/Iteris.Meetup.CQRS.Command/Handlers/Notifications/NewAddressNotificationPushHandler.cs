using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Command.Handlers.Notifications
{
    public class NewAddressNotificationPushHandler : INotificationHandler<NewAddressNotification>
    {
        private readonly ILogger<NewAddressNotificationPushHandler> _logger;

        public NewAddressNotificationPushHandler(ILogger<NewAddressNotificationPushHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(NewAddressNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UserID: {notification.UserId} | AddressId: {notification.AddressId} | DtCreated: {notification.DtCreated}");
            _logger.LogInformation("Acesse o app agora e verifique seu novo endereço cadastrado.");
        }
    }
}
