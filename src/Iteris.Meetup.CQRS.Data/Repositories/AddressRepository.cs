using Dapper;
using Iteris.Meetup.CQRS.Data.Statements;
using Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Data.Repositories
{
    public class AddressRepository : RepositoryBase, IAddressRepository
    {
        public async Task<int> Create(Address address)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();

            await conn.ExecuteAsync(AddressStatements.CreateAddress,
                new
                {
                    userId = address.UserId,
                    streetName = address.StreetName,
                    streetNumber = address.StreetNumber,
                    complement = address.Complement,
                    cep = address.Cep,
                    city = address.City,
                    state = address.State,
                    name = address.Name
                });
            return await conn.QueryFirstOrDefaultAsync<int>("SELECT last_insert_rowid() FROM ADDRESS");
        }

        public async Task<Address> GetById(int addressId)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();

            return await conn.QueryFirstOrDefaultAsync<Address>(AddressStatements.GetById, new { addressId });
        }

        public async Task<List<Address>> GetByUserId(int userId)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();
            var addresses = await conn.QueryAsync<Address>(AddressStatements.GetByUserId, new
            {
                userId
            });
            return addresses.ToList();
        }
    }
}