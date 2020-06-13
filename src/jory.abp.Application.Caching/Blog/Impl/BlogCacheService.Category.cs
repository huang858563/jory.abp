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
        private const string CategoryPrefix = CachePrefix.BlogCategory;

        private const string KeyGetCategory = CategoryPrefix + ":GetCategory-{0}";
        private const string KeyQueryCategories = CategoryPrefix + ":QueryCategories";

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCategoryAsync(string name, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyGetCategory.FormatWith(name), factory, CacheStrategy.ONE_DAY);
        }

        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync(Func<Task<ServiceResult<IEnumerable<QueryCategoryDto>>>> factory)
        {
            return await Cache.GetOrAddAsync(KeyQueryCategories, factory, CacheStrategy.ONE_DAY);
        }
    }
}
