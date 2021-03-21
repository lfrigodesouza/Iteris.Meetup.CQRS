using Iteris.Meetup.Domain.Entities;

namespace Iteris.Meetup.CQRS.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User GetById(int userId);
    }
}