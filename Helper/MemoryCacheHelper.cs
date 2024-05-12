using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Helpers
{
    public class MemoryCacheHelper
    {
        public static IMemoryCache memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T? Get<T>(string key)
        {
            return memoryCache.Get<T>(key);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T? Set<T>(string key, T value)
        {
            return memoryCache.Set(key, value);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T? GetOrCreate<T>(string key, Func<ICacheEntry, T> func)
        {
            return memoryCache.GetOrCreate(key, func);
        }
    }
}
