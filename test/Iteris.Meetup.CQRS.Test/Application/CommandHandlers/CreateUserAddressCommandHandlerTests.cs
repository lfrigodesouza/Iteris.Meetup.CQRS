using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Iteris.Meetup.CQRS.Application.Commands.CreateUserAddress;
using Iteris.Meetup.CQRS.CrossCutting;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Iteris.Meetup.CQRS.Test.Application.CommandHandlers
{
    public class CreateUserAddressCommandHandlerTests
    {
        private readonly IAddressRepository _addressRepository;
        private readonly CreateUserAddressCommand _command;
        private readonly CreateUserAddressCommandHandler _handler;
        private readonly IMediator _mediator;

        public CreateUserAddressCommandHandlerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _addressRepository = Substitute.For<IAddressRepository>();
            var logger = Substitute.For<ILogger<CreateUserAddressCommandHandler>>();
            _handler = new CreateUserAddressCommandHandler(logger, _mediator, _addressRepository);
            _command = new CreateUserAddressCommand
            {
                Name = "Casa",
                UserId = 10,
                StreetName = "Rua Komakite Ikeda",
                StreetNumber = 1592,
                Cep = "18303260",
                City = "Capão Bonito",
                State = "SP"
            };
        }

        [Fact]
        public async Task WhenThereIsAnException_ShouldReturnInternalServerError()
        {
            _addressRepository.Create(null).ThrowsForAnyArgs(new Exception());
            var response = await _handler.Handle(_command, CancellationToken.None);
            response.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
            response.IsFailure.Should().BeTrue();
        }

        [Fact]
        public async Task WhenCreatedSuccessfully_ShouldReturnCreated()
        {
            var response = await _handler.Handle(_command, CancellationToken.None);
            _mediator.ReceivedWithAnyArgs(1).Dispatch(null, CancellationToken.None);
            response.StatusCode.Should().Be((int) HttpStatusCode.Created);
            response.IsFailure.Should().BeFalse();
        }
    }
}