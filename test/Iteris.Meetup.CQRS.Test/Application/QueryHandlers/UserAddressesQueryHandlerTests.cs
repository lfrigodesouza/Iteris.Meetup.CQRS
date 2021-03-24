using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Iteris.Meetup.CQRS.Application.Models;
using Iteris.Meetup.CQRS.Application.Queries.UserAdresses;
using Iteris.Meetup.CQRS.Domain.Interfaces.Repositories;
using Iteris.Meetup.CQRS.Test.Fakes;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Iteris.Meetup.CQRS.Test.Application.QueryHandlers
{
    public class UserAddressesQueryHandlerTests
    {
        private const int USER_ID = 3;
        private readonly ICacheDbRepository _cacheDbRepository;
        private readonly UserAddressesQueryHandler _handler;

        public UserAddressesQueryHandlerTests()
        {
            var logger = Substitute.For<ILogger<UserAddressesQueryHandler>>();
            _cacheDbRepository = Substitute.For<ICacheDbRepository>();
            _handler = new UserAddressesQueryHandler(logger, _cacheDbRepository);
        }

        [Fact]
        public async Task WhenNoAddresses_ShouldReturnNoContent()
        {
            _cacheDbRepository.GetItemFromCache<List<UserAddress>>(Arg.Any<string>()).Returns(new List<UserAddress>());
            var query = new UserAddressesQuery(USER_ID);
            var response = await _handler.Handle(query, CancellationToken.None);
            response.IsFailure.Should().BeFalse();
            response.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
        }


        [Fact]
        public async Task WhenThereIsAnException_ShouldReturnInternalServerError()
        {
            _cacheDbRepository.GetItemFromCache<List<UserAddress>>(Arg.Any<string>()).Throws(new Exception());
            var query = new UserAddressesQuery(USER_ID);
            var response = await _handler.Handle(query, CancellationToken.None);
            response.IsFailure.Should().BeTrue();
            response.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task WhenUserHasAddresses_ShouldReturnOk()
        {
            var userAddresses = UserAddressesFake.ValidAddresses();
            _cacheDbRepository.GetItemFromCache<List<UserAddress>>(Arg.Any<string>()).Returns(userAddresses);
            var query = new UserAddressesQuery(USER_ID);
            var response = await _handler.Handle(query, CancellationToken.None);
            response.IsFailure.Should().BeFalse();
            response.StatusCode.Should().Be((int) HttpStatusCode.OK);
            response.Content.Should().BeEquivalentTo(userAddresses);
        }
    }
}