using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate
{
    public interface IUserRepository
    {
        Task<User> GetById(int userId);

        Task<int> Create(User user);
    }
}