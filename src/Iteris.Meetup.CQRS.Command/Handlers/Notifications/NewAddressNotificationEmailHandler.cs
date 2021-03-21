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
    public class NewAddressNotificationEmailHandler : INotificationHandler<NewAddressNotification>
    {
        private readonly ILogger<NewAddressNotificationEmailHandler> _logger;

        public NewAddressNotificationEmailHandler(ILogger<NewAddressNotificationEmailHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(NewAddressNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"UserID: {notification.UserId} | AddressId: {notification.AddressId} | DtCreated: {notification.DtCreated}");
            _logger.LogInformation("Usuário, um novo endereço foi cadastrado na sua conta. Se não foi você, clique aqui e verifique suas informações.");
        }
    }
}
