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
        /// 获取标签名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> GetTagAsync(string name);

        /// <summary>
        /// 查询标签列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryTagDto>>> QueryTagsAsync();
    }
}
