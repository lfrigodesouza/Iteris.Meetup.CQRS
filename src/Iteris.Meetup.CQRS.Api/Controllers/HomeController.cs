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
    }
}