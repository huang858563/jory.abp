using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using jory.abp.Application.Contracts.Blog;
using jory.abp.Domain.Blog;

namespace jory.abp.Application
{
    public class JoryAbpAutoMapperProfile : Profile
    {
        public JoryAbpAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();

            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
