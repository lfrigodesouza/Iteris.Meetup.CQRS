using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Api.Behaviors
{
    public class LoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggerBehavior<TRequest, TResponse>> _logger;

        public LoggerBehavior(ILogger<LoggerBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation(
                $"Início do processamento | Request: {typeof(TRequest).Name}");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var response = await next();
            stopWatch.Stop();
            _logger.LogInformation(
                $"Fim do processamento | Request: {typeof(TRequest).Name} | Duração: {stopWatch.Elapsed.TotalSeconds}");
            return response;
        }
    }
}
