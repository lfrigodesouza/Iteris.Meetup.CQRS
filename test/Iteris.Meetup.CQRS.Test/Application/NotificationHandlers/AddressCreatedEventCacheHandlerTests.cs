using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress;
using Iteris.Meetup.CQRS.Application.Models;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using Iteris.Meetup.CQRS.Domain.Interfaces.Repositories;
using Iteris.Meetup.CQRS.Test.Fakes;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Iteris.Meetup.CQRS.Test.Application.NotificationHandlers
{
    public class AddressCreatedEventCacheHandlerTests
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICacheDbRepository _cacheDbRepository;
        private readonly AddressCreatedEventCacheHandler _handler;
        private readonly AddressCreatedEvent _notification;

        public AddressCreatedEventCacheHandlerTests()
        {
            var logger = Substitute.For<ILogger<AddressCreatedEventCacheHandler>>();
            _cacheDbRepository = Substitute.For<ICacheDbRepository>();
            _addressRepository = Substitute.For<IAddressRepository>();
            _handler = new AddressCreatedEventCacheHandler(logger, _cacheDbRepository, _addressRepository);
            _notification = new AddressCreatedEvent(AddressFake.Valid());
        }

        [Fact]
        public async Task WhenNotified_ShouldAddItemToCache()
        {
            _addressRepository.GetByUserId(0).ReturnsForAnyArgs(new List<Address> {AddressFake.Valid()});
            await _handler.Handle(_notification, CancellationToken.None);
            _cacheDbRepository.ReceivedWithAnyArgs(1).AddItemToCache(null, Arg.Any<List<UserAddress>>());
        }
    }
}