using Iteris.Meetup.Domain.Responses;
using MediatR;

namespace Iteris.Meetup.CQRS.Query.Queries
{
    public class UserAddressesQuery : IRequest<Response>
    {
        public UserAddressesQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
