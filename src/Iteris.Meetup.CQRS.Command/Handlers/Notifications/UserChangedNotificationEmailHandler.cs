using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Notifications;
using Iteris.Meetup.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Command.Handlers.Notifications
{
    public class UserChangedNotificationEmailHandler : INotificationHandler<UserChangedNotification>
    {
        private readonly ILogger<UserChangedNotificationEmailHandler> _logger;

        public UserChangedNotificationEmailHandler(ILogger<UserChangedNotificationEmailHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(UserChangedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                $"UserID: {notification.UserId} | DtChanged: {notification.DtChanged}");
            switch (notification.Type)
            {
                case ChangeTypeEnum.UpdatedItem:
                    _logger.LogInformation(
                        "Usuário, um novo endereço foi cadastrado na sua conta. Se não foi você, clique aqui e verifique suas informações.");
                    break;
                case ChangeTypeEnum.NewItem:
                    _logger.LogInformation("Seu cadastro foi realizado com sucesso!");
                    break;
            }
        }
    }
}
