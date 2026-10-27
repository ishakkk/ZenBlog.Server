using AutoMapper;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
        }
    }
}
