using jory.abp.Application.Contracts.Blog;
using jory.abp.Domain.Shared;
using jory.abp.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jory.abp.Application.Caching.Blog.Impl
{
    public partial class BlogCacheService
    {
        private const string FriendLinkPrefix = CachePrefix.BlogFriendLink;

        private const string KeyQueryFriendLinks = FriendLinkPrefix + ":FriendLink:QueryFriendLinks";

        /// <summary>
        /// 查询友链列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync(Func<Task<ServiceResult<IEnumerable<FriendLinkDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryFriendLinks, factory, CacheStrategy.ONE_DAY);
        }
    }
}
