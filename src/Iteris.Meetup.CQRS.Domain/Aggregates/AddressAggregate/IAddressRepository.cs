using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Domain.Aggregates.AddressAggregate
{
    public interface IAddressRepository
    {
        Task<int> Create(Address address);

        Task<Address> GetById(int addressId);

        Task<List<Address>> GetByUserId(int userId);
    }
}