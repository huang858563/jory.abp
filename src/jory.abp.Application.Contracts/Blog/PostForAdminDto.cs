using System.Collections.Generic;
namespace jory.abp.Application.Contracts.Blog
{
    public class PostForAdminDto : PostDto
    {
        /// <summary>
        /// 标签列表
        /// </summary>
        public IEnumerable<string> Tags { get; set; }
    }
}