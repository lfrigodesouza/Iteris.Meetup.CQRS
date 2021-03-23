using Iteris.Meetup.CQRS.Domain.Interfaces.Repositories;
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

        public void AddItemToCache<T>(string key, T item)
        {
            if (_memoryCache.TryGetValue(key, out _)) _memoryCache.Remove(key);
            _memoryCache.Set(key, item);
        }

        public T GetItemFromCache<T>(string key)
        {
            return _memoryCache.TryGetValue(key, out var cacheEntry)
                ? (T) cacheEntry
                : default;
        }
    }
}
