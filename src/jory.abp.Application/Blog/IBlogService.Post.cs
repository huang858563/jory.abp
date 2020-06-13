using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.Application.Contracts;
using jory.abp.Application.Contracts.Blog;
using jory.abp.ToolKits.Base;

namespace jory.abp.Application.Blog
{
    public partial interface IBlogService
    {
        /// <summary>
        /// 根据URL获取文章详情
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<ServiceResult<PostDetailDto>> GetPostDetailAsync(string url);

        /// <summary>
        /// 分页查询文章列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<ServiceResult<PagedList<QueryPostDto>>> QueryPostsAsync(PagingInput input);

        /// <summary>
        /// 通过分类名称查询文章列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByCategoryAsync(string name);

        /// <summary>
        /// 通过标签名称查询文章列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<ServiceResult<IEnumerable<QueryPostDto>>> QueryPostsByTagAsync(string name);
    }
}
