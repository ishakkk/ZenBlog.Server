using AutoMapper;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Mappings
{
    public class SubCommentsAppingProfile : Profile
    {
        public SubCommentsAppingProfile()
        {
            CreateMap<SubComment, CreateSubCommentsCommand>().ReverseMap();
            CreateMap<SubComment, UpdateSubCommentsCommand>().ReverseMap();
            CreateMap<SubComment, GetSubCommentByIdQueryResult>().ReverseMap();
            CreateMap<SubComment, GetSubCommentQueryResult>().ReverseMap();
        }
    }
}
