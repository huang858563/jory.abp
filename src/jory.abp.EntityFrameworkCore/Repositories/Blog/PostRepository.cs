﻿using System;
using System.Collections.Generic;
using System.Text;
using jory.abp.Domain.Blog;
using jory.abp.Domain.Blog.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace jory.abp.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// PostRepository
    /// </summary>
    public class PostRepository : EfCoreRepository<JoryAbpDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<JoryAbpDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
