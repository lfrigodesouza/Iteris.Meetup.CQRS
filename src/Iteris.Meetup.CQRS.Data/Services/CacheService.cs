using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteris.Meetup.CQRS.Data.Services
{
    public class CacheService : ICacheService
    {
        private IMemoryCache _cache;

        public CacheService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public T GetValueByKey(string key)
        {
           return _cache.Get(key)
        }
    }
}
