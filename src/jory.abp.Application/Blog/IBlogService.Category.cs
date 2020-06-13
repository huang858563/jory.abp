using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.Application.Contracts.Blog;
using jory.abp.ToolKits.Base;

namespace jory.abp.Application.Blog
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetCategoryAsync(string name);

        /// <summary>
        /// 查询分类列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryCategoryDto>>> QueryCategoriesAsync();
    }
}
