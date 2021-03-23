using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Iteris.Meetup.CQRS.CrossCutting
{
    public static class MediatorExtension
    {
        public static async Task Dispatch(this IMediator mediator, IReadOnlyCollection<INotification> domainEvents,
            CancellationToken cancellationToken)
        {
            var tasks = domainEvents.Select(async domainEvent =>
            {
                await mediator.Publish(domainEvent, cancellationToken);
            });

            await Task.WhenAll(tasks);
        }
    }
}