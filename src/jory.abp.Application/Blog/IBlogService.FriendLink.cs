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
        /// 查询友链列表
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<FriendLinkDto>>> QueryFriendLinksAsync();
    }
}
