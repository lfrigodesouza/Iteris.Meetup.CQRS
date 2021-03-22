using System.Collections.Generic;
using System.Threading.Tasks;
using Iteris.Meetup.Domain.Entities;

namespace Iteris.Meetup.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<int> Create(Address address);
        Task<Address> GetById(int addressId);
        Task<List<Address>> GetByUserId(int userId);
    }
}
