using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;
using Iteris.Meetup.CQRS.Data.Statements;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Interfaces.Repositories;

namespace Iteris.Meetup.CQRS.Data.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public async Task<int> Create(User user)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();

            await conn.ExecuteAsync(UserStatements.CreateUser,
                new {name = user.Name, surname = user.Surname, birthday = user.Birthday, cpf = user.Cpf});
            var userId = await conn.QueryFirstOrDefaultAsync<int>("SELECT last_insert_rowid() FROM USER");

            return userId;
        }

        Task<User> IUserRepository.GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
