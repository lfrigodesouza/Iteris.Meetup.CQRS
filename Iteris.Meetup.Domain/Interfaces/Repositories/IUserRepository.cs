using Iteris.Meetup.Domain.Entities;

namespace Iteris.Meetup.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User GetById(int userId);
    }
}