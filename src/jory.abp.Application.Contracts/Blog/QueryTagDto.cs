﻿namespace jory.abp.Application.Contracts.Blog
{
    public class QueryTagDto : TagDto
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
    }
}