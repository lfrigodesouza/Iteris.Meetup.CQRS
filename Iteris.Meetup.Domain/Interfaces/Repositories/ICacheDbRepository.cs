using System.Threading.Tasks;

namespace Iteris.Meetup.Domain.Interfaces.Repositories
{
    public interface ICacheDbRepository
    {
        Task AddItemToCache<T>(string key, T item);
        Task<T> GetItemFromCache<T>(string key);
    }
}
