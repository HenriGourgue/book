using Microsoft.Extensions.Caching.Memory;

namespace book.Custom
{
    public class CacheManager
    {
        public MemoryCache Cache { get; set; }
        
        public CacheManager()
        {
            Cache = new MemoryCache(new MemoryCacheOptions { });
        }
    }
}