using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Iteris.Meetup.CQRS.Application.Commands.CreateUser;
using Iteris.Meetup.CQRS.CrossCutting;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Iteris.Meetup.CQRS.Test.Application.CommandHandlers
{
    public class CreateUserCommandHandlerTests
    {
        private const int USER_ID = 6;
        private readonly IAddressRepository _addressRepository;
        private readonly CreateUserCommand _command;
        private readonly CreateUserCommandHandler _handler;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _addressRepository = Substitute.For<IAddressRepository>();
            _mediator = Substitute.For<IMediator>();
            var logger = Substitute.For<ILogger<CreateUserCommandHandler>>();
            _handler = new CreateUserCommandHandler(logger, _userRepository, _addressRepository, _mediator);
            _command = new CreateUserCommand
            {
                Name = "Vitória",
                Surname = "Barros Melo",
                Birthday = DateTime.Now,
                Cpf = "78146849865",
                AddressName = "Casa",
                StreetName = "Rua Doutor Ephigênio Barbosa da Silva",
                StreetNumber = 214,
                Cep = "58052310",
                City = "João Pessoa",
                State = "PB"
            };
        }

        [Fact]
        public async Task WhenThereIsAnException_ShouldReturnInternalServerError()
        {
            _addressRepository.Create(null).ThrowsForAnyArgs(new Exception());
            var response = await _handler.Handle(_command, CancellationToken.None);
            response.IsFailure.Should().BeTrue();
            response.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task WhenCreatedSuccessfully_ShouldReturnCreated()
        {
            _userRepository.Create(null).ReturnsForAnyArgs(USER_ID);
            var response = await _handler.Handle(_command, CancellationToken.None);

            response.StatusCode.Should().Be((int) HttpStatusCode.Created);
            response.IsFailure.Should().BeFalse();
            response.Content.Should().BeEquivalentTo(USER_ID);
            _mediator.Received(2).Dispatch(Arg.Any<IReadOnlyCollection<INotification>>(), Arg.Any<CancellationToken>());
        }
    }
}