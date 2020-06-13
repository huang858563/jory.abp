using jory.abp.Application.Contracts.Blog;
using jory.abp.Domain.Shared;
using jory.abp.ToolKits.Base;
using jory.abp.ToolKits.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jory.abp.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    { 
        private const string TagPrefix = CachePrefix.BlogTag;

        private const string KeyGetTag = TagPrefix + ":GetTag-{0}";
        private const string KeyQueryTags = TagPrefix + ":QueryTags";

        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetTagAsync(string name, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGetTag.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync(Func<Task<ServiceResult<IEnumerable<QueryTagDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryTags, factory, CacheStrategy.ONE_DAY);
        }
    }
}
