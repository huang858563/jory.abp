﻿using jory.abp.Application.Contracts;
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
        private const string PostPrefix = CachePrefix.BlogPost;

        private const string KeyGetPostDetail = PostPrefix + ":GetPostDetail-{0}";
        private const string KeyQueryPosts = PostPrefix + ":QueryPosts-{0}-{1}";
        private const string KeyQueryPostsByCategory = PostPrefix + ":QueryPostsByCategory-{0}";
        private const string KeyQueryPostsByTag = PostPrefix + ":QueryPostsByTag-{0}";

        /// <summary>
        /// 根据URL获取文章详情
        /// </summary>
        /// <param name="url"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url, Func<Task<ServiceResult<PostDetailDto>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGetPostDetail.FormatWith(url), factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input, Func<Task<ServiceResult<PagedList<QueryPostDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryPosts.FormatWith(input.Page, input.Limit), factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 通过分类名称查询文章列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByCategoryAsync(string name, Func<Task<ServiceResult<IEnumerable<QueryPostDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryPostsByCategory.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 通过标签名称查询文章列表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByTagAsync(string name, Func<Task<ServiceResult<IEnumerable<QueryPostDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryPostsByTag.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }
    }
}
