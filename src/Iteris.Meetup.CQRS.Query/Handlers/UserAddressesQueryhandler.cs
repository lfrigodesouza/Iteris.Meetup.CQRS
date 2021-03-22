using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Iteris.Meetup.CQRS.Query.Queries;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Interfaces.Repositories;
using Iteris.Meetup.Domain.Responses;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Iteris.Meetup.CQRS.Query.Handlers
{
    public class UserAddressesQueryHandler : IRequestHandler<UserAddressesQuery, Response>
    {
        private readonly ICacheDbRepository _cacheDbRepository;
        private readonly ILogger<UserAddressesQuery> _logger;

        public UserAddressesQueryHandler(ILogger<UserAddressesQuery> logger,
            ICacheDbRepository cacheDbRepository)
        {
            _logger = logger;
            _cacheDbRepository = cacheDbRepository;
        }

        public async Task<Response> Handle(UserAddressesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userAddresses = _cacheDbRepository.GetItemFromCache<List<UserAddress>>(request.UserId.ToString());
                if (userAddresses == null || !userAddresses.Any())
                    return Response.Ok(HttpStatusCode.NoContent);

                return Response.Ok(userAddresses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível obter os endereços do usuário {request.UserId}");
                return Response.Fail(HttpStatusCode.InternalServerError,
                    "Não foi possível obter os endereços do usuário");
            }
        }
    }
}
