using AutoMapper;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Mappings
{
    public class BlogsMappingProfile : Profile
    {
        public BlogsMappingProfile()
        {
            CreateMap<Blog, GetBlogsQueryResult>().ReverseMap();
            CreateMap<Blog, GetBlogsByIdQueryResult>().ReverseMap();
            CreateMap<Blog, CreateBlogCommand>().ReverseMap();
            CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
            CreateMap<Blog, GetBlogsByCategoryIdQueryResult>().ReverseMap();
        }
    }
}
