using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.CQRS.Query.Queries;
using Iteris.Meetup.CQRS.Query.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iteris.Meetup.CQRS.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("user")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : StatusCode(response.StatusCode, response.Content);
        }

        [HttpPost("address")]
        [ProducesResponseType(typeof(void), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand createAddressCommand)
        {
            var response = await _mediator.Send(createAddressCommand);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : StatusCode(response.StatusCode, response.Content);
        }

        [HttpGet("address/{userId}")]
        [ProducesResponseType(typeof(UserAddressesResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<string>), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAddresses([FromRoute] int userId)
        {
            var query = new UserAddressesQuery(userId);
            var response = await _mediator.Send(query);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : StatusCode(response.StatusCode, response.Content);
        }
    }
}
