using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Api.Behaviors
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators.Select(v => v.Validate(request))
                                      .SelectMany(r => r.Errors)
                                      .Where(e => e is not null)
                                      .ToList();

            if (failures.Any())
                return (TResponse) Response.Fail(HttpStatusCode.BadRequest,
                    failures.Select(x => x.ErrorMessage).ToArray());

            return await next();
        }
    }
}
