using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using DingTalk.Web.Common;

namespace DingTalk.Web.Controllers
{
    public class CacheController : Controller
    {
        private IMemoryCache _cache;
        public CacheController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet]
        [Route(nameof(TryGetValueAndSet))]
        public ActionResult TryGetValueAndSet()
        {
            DateTime cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));
                // Save data in cache.
                _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
            }

            string dd_accesstoken = string.Empty;
            if (!_cache.TryGetValue(CacheKeys.DingTalkEntry, out dd_accesstoken))
            {
                // Key not in cache, so get data.
                dd_accesstoken = "test" + DateTime.Now.ToShortTimeString();
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));
                // Save data in cache.
                _cache.Set(CacheKeys.DingTalkEntry, dd_accesstoken, cacheEntryOptions);
            }

            return Ok(new { cacheEntry, dd_accesstoken });
        }

        [HttpGet]
        [Route(nameof(CacheGetOrCreate))]
        public IActionResult CacheGetOrCreate()
        {
            var cacheEntry = _cache.GetOrCreate(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return DateTime.Now;
            });

            return Ok(cacheEntry);
        }

        [HttpGet]
        [Route(nameof(CacheGetOrCreateAsync))]
        public async Task<IActionResult> CacheGetOrCreateAsync()
        {
            var cacheEntry = await _cache.GetOrCreateAsync(CacheKeys.Entry, entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return Task.FromResult(DateTime.Now);
            });

            return Ok(cacheEntry);
        }

        [HttpGet]
        [Route(nameof(CacheGet))]
        public IActionResult CacheGet()
        {
            var cacheEntry = _cache.Get<DateTime?>(CacheKeys.Entry);
            return Ok(cacheEntry);
        }
    }
}