using System.Threading.Tasks;
using Iteris.Meetup.Domain.Entities;

namespace Iteris.Meetup.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int userId);
        Task<int> Create(User user);
    }
}