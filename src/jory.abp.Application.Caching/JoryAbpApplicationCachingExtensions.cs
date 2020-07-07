using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.Domain.Configurations;
using jory.abp.Domain.Shared;
using jory.abp.ToolKits.Extensions;
using Microsoft.Extensions.Caching.Distributed;

namespace jory.abp.Application.Caching
{
    public static class JoryAbpApplicationCachingExtensions
    {
        /// <summary>
        /// 获取或添加缓存
        /// </summary>
        /// <typeparam name="TCacheItem"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static async Task<TCacheItem> GetOrAddAsync<TCacheItem>(this IDistributedCache cache, string key,
            Func<Task<TCacheItem>> factory, int minutes)
        {
            TCacheItem cacheItem;
            if (AppSettings.Caching.IsOpen)
            {
                var result = await cache.GetStringAsync(key);
                if (string.IsNullOrEmpty(result))
                {
                    cacheItem = await factory.Invoke();

                    var options = new DistributedCacheEntryOptions();
                    if (minutes != CacheStrategy.NEVER)
                    {
                        options.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minutes);
                    }

                    await cache.SetStringAsync(key, cacheItem.ToJson(), options);
                }
                else
                {
                    cacheItem = result.FromJson<TCacheItem>();
                }
            }
            else
            {
                cacheItem = await factory.Invoke();
            }

            return cacheItem;
        }
    }
}
