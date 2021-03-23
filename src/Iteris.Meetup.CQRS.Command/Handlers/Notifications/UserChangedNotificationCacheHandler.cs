using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Notifications;
using Iteris.Meetup.CQRS.Domain.Entities;
using Iteris.Meetup.CQRS.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Command.Handlers.Notifications
{
    public class UserChangedNotificationCacheHandler : INotificationHandler<UserChangedNotification>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICacheDbRepository _cacheDbRepository;
        private readonly ILogger<UserChangedNotificationCacheHandler> _logger;

        public UserChangedNotificationCacheHandler(ILogger<UserChangedNotificationCacheHandler> logger,
            ICacheDbRepository cacheDbRepository,
            IAddressRepository addressRepository)
        {
            _logger = logger;
            _cacheDbRepository = cacheDbRepository;
            _addressRepository = addressRepository;
        }

        public async Task Handle(UserChangedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Atualizando cache de endereços do usuário {notification.UserId}");
            var addresses = await _addressRepository.GetByUserId(notification.UserId);

            var userAddresses = addresses.Select(address => new UserAddress
                                         {
                                             Name = address.Name,
                                             Cep = address.Cep,
                                             City = address.City,
                                             State = address.State,
                                             Street = $"{address.StreetName}, {address.StreetNumber}" +
                                                      (string.IsNullOrWhiteSpace(address.Complement)
                                                          ? string.Empty
                                                          : $", {address.Complement}")
                                         })
                                         .ToList();

            _cacheDbRepository.AddItemToCache(notification.UserId.ToString(), userAddresses);
        }
    }
}
