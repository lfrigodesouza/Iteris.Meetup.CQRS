using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;
using Iteris.Meetup.CQRS.Data.Statements;
using Iteris.Meetup.Domain.Entities;
using Iteris.Meetup.Domain.Interfaces.Repositories;

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
            var addressId = await conn.QueryFirstOrDefaultAsync<int>("SELECT last_insert_rowid() FROM ADDRESS");

            return addressId;
        }

        public Task<Address> GetById(int addressId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>> GetByUserId(int userId)
        {
            await using var conn = new SQLiteConnection(ConnString);
            conn.Open();
            var addresses = await conn.QueryAsync<Address>(AddressStatements.GetByUserId, new
            {
                userId
            });
            return addresses;
        }
    }
}