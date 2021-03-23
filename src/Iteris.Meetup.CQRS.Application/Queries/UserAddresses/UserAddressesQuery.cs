using MediatR;

namespace Iteris.Meetup.CQRS.Application.Queries.UserAdresses
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