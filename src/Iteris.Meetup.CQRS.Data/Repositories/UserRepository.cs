using System;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Interfaces.Repositories;

namespace Iteris.Meetup.CQRS.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}