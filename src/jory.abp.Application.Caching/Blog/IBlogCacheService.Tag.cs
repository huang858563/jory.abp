﻿using jory.abp.Application.Contracts.Blog;
using jory.abp.ToolKits.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace jory.abp.Application.Caching.Blog
{
    public partial interface IBlogCacheService
    {
        /// <summary>
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync(string name, Func<Task<ServiceResult<string>>> factory);

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync(Func<Task<ServiceResult<IEnumerable<QueryTagDto>>>> factory);
    }
}
