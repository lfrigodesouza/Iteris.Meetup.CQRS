using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;
using Iteris.Meetup.CQRS.Data.Statements;
using Iteris.Meetup.CQRS.Domain.Aggregates.UserAggregate;

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
            return await conn.QueryFirstOrDefaultAsync<int>("SELECT last_insert_rowid() FROM USER");
        }

        public async Task<User> GetById(int userId)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();

            return await conn.QueryFirstOrDefaultAsync<User>(UserStatements.GetById, new {userId});
        }
    }
}