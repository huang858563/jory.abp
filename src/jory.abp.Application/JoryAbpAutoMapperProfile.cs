using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using jory.abp.Application.Contracts.Blog;
using jory.abp.Application.Contracts.Blog.Params;
using jory.abp.Domain.Blog;

namespace jory.abp.Application
{
    public class JoryAbpAutoMapperProfile : Profile
    {
        public JoryAbpAutoMapperProfile()
        {
            CreateMap<FriendLink, FriendLinkDto>();

            CreateMap<Post, PostForAdminDto>().ForMember(x => x.Tags, opt => opt.Ignore());

            CreateMap<EditPostInput, Post>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<EditCategoryInput, Category>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<EditTagInput, Tag>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FriendLink, QueryFriendLinkForAdminDto>();

            CreateMap<EditFriendLinkInput, FriendLink>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
