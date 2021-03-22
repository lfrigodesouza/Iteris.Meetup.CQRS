using System.Threading.Tasks;

namespace Iteris.Meetup.Domain.Interfaces.Repositories
{
    public interface ICacheDbRepository
    {
        void AddItemToCache<T>(string key, T item);
        T GetItemFromCache<T>(string key);
    }
}
