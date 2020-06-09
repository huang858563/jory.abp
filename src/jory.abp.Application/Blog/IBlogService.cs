using jory.abp.Application.Contracts.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using jory.abp.ToolKits.Base;

namespace jory.abp.Application.Blog
{
    public interface IBlogService
    {
        Task<ServiceResult<string>> InsertPostAsync(PostDto dto);

        Task<ServiceResult> DeletePostAsync(int id);

        Task<ServiceResult<string>> UpdatePostAsync(int id, PostDto dto);

        Task<ServiceResult<PostDto>> GetPostAsync(int id);
    }
}
