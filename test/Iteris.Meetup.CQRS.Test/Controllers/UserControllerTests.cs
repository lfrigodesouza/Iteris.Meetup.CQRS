﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Iteris.Meetup.CQRS.Api.Controllers;
using Iteris.Meetup.CQRS.Application;
using Iteris.Meetup.CQRS.Application.Commands.CreateUser;
using Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress;
using Iteris.Meetup.CQRS.Application.Queries.UserAdresses;
using Iteris.Meetup.CQRS.Test.Fakes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Iteris.Meetup.CQRS.Test.Controllers
{
    public class UserControllerTests
    {
        private const int USER_ID = 19;
        private readonly UserController _controller;
        private readonly IMediator _mediator;

        public UserControllerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _controller = new UserController(_mediator);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task WhenCreateUserHasError_ShouldReturnCorrectStatusCode(HttpStatusCode statusCode)
        {
            var errorResponse = Response.Fail(statusCode, $"Generic {statusCode.ToString()} Error message");
            _mediator.Send(Arg.Any<CreateUserCommand>()).Returns(errorResponse);

            var response = await _controller.CreateUser(new CreateUserCommand()) as ObjectResult;
            response.StatusCode.Value.Should().Be((int) statusCode);
            response.Value.Should().BeEquivalentTo(new[] {$"Generic {statusCode.ToString()} Error message"});
        }

        [Fact]
        public async Task WhenUserCreated_ShouldReturnCreatedStatusCode()
        {
            var successResponse = Response.Ok(HttpStatusCode.Created);
            _mediator.Send(Arg.Any<CreateUserCommand>()).Returns(successResponse);

            var response = await _controller.CreateUser(new CreateUserCommand()) as ObjectResult;
            response.StatusCode.Should().Be((int) HttpStatusCode.Created);
            response.Value.Should().BeEquivalentTo(string.Empty);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task WhenCreateAddressHasError_ShouldReturnCorrectStatusCode(HttpStatusCode statusCode)
        {
            var errorResponse = Response.Fail(statusCode, $"Generic {statusCode.ToString()} Error message");
            _mediator.Send(Arg.Any<CreateUserAddressCommand>()).Returns(errorResponse);

            var response = await _controller.CreateAddress(USER_ID, new CreateUserAddressCommand()) as ObjectResult;
            response.StatusCode.Value.Should().Be((int) statusCode);
            response.Value.Should().BeEquivalentTo(new[] {$"Generic {statusCode.ToString()} Error message"});
        }

        [Fact]
        public async Task WhenAddressCreated_ShouldReturnCreatedStatusCode()
        {
            var successResponse = Response.Ok(HttpStatusCode.Created);
            _mediator.Send(Arg.Any<CreateUserAddressCommand>()).Returns(successResponse);

            var response = await _controller.CreateAddress(USER_ID, new CreateUserAddressCommand()) as ObjectResult;
            response.StatusCode.Should().Be((int) HttpStatusCode.Created);
            response.Value.Should().BeEquivalentTo(string.Empty);
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task WhenGetAddressesHasError_ShouldReturnCorrectStatusCode(HttpStatusCode statusCode)
        {
            var errorResponse = Response.Fail(statusCode, $"Generic {statusCode.ToString()} Error message");
            _mediator.Send(Arg.Any<UserAddressesQuery>()).Returns(errorResponse);

            var response = await _controller.GetAddresses(1) as ObjectResult;
            response.StatusCode.Value.Should().Be((int) statusCode);
            response.Value.Should().BeEquivalentTo(new[] {$"Generic {statusCode.ToString()} Error message"});
        }

        [Fact]
        public async Task WhenGetAddress_ShouldReturnCorrectData()
        {
            var userAddresses = UserAddressesFake.ValidAddresses();
            var successResponse = Response.Ok(HttpStatusCode.OK, userAddresses);
            _mediator.Send(Arg.Any<UserAddressesQuery>()).Returns(successResponse);

            var response = await _controller.GetAddresses(7) as ObjectResult;
            response.StatusCode.Should().Be((int) HttpStatusCode.OK);
            response.Value.Should().BeEquivalentTo(userAddresses);
        }

        [Fact]
        public async Task WhenGetAddressNoAddresses_ShouldReturnNoContent()
        {
            var successResponse = Response.Ok(HttpStatusCode.NoContent);
            _mediator.Send(Arg.Any<UserAddressesQuery>()).Returns(successResponse);

            var response = await _controller.GetAddresses(7) as ObjectResult;
            response.StatusCode.Should().Be((int) HttpStatusCode.NoContent);
            response.Value.Should().BeEquivalentTo(string.Empty);
        }
    }
}