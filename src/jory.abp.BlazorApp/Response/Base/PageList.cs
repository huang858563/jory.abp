﻿using jory.abp.BlazorApp.Response.Base.Paged;
using System.Collections.Generic;

namespace jory.abp.BlazorApp.Response.Base
{
    /// <summary>
    /// 分页响应实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        public PagedList()
        {
        }

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}
