using Iteris.Meetup.CQRS.Application.Models;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using Iteris.Meetup.CQRS.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress
{
    public class AddressCreatedEventCacheHandler : INotificationHandler<AddressCreatedEvent>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICacheDbRepository _cacheDbRepository;
        private readonly ILogger<AddressCreatedEventCacheHandler> _logger;

        public AddressCreatedEventCacheHandler(ILogger<AddressCreatedEventCacheHandler> logger,
            ICacheDbRepository cacheDbRepository,
            IAddressRepository addressRepository)
        {
            _logger = logger;
            _cacheDbRepository = cacheDbRepository;
            _addressRepository = addressRepository;
        }

        public async Task Handle(AddressCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Atualizando cache de endereços do usuário {notification.Address.UserId}");
            var addresses = await _addressRepository.GetByUserId(notification.Address.UserId);

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
            }).ToList();

            _cacheDbRepository.AddItemToCache(notification.Address.UserId.ToString(), userAddresses);
        }
    }
}