using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Command.Commands;
using Iteris.Meetup.CQRS.Query.Queries;
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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand createUserCommand)
        {
            var response = await _mediator.Send(createUserCommand);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : Ok(response.Content);
        }

        [HttpPost("address")]
        public async Task<IActionResult> CreateAddress([FromBody] CreateAddressCommand createAddressCommand)
        {
            var response = await _mediator.Send(createAddressCommand);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : Ok(response.Content);
        }

        [HttpGet("address/{userId}")]
        public async Task<IActionResult> GetAddresses([FromRoute] int userId)
        {
            var query = new UserAddressesQuery(userId);
            var response = await _mediator.Send(query);
            return response.IsFailure
                ? StatusCode(response.StatusCode, response.ErrorMessages)
                : Ok(response.Content);
        }
    }
}