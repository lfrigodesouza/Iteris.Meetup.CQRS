using System.Threading.Tasks;
using Iteris.Meetup.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Iteris.Meetup.CQRS.Data.Repositories
{
    public class CacheDbRepository : ICacheDbRepository
    {
        private readonly IMemoryCache _memoryCache;

        public CacheDbRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task AddItemToCache<T>(string key, T item)
        {
            if (_memoryCache.TryGetValue(key, out _)) _memoryCache.Remove(key);
            _memoryCache.Set(key, item);
        }

        public async Task<T> GetItemFromCache<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out var cacheEntry)) return (T) cacheEntry;

            return default;
        }
    }
}
