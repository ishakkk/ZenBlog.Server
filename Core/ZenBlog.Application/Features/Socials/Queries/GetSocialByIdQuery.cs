using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Socials.Result;

namespace ZenBlog.Application.Features.Socials.Queries
{
    public record GetSocialByIdQuery(Guid Id) : IRequest<BaseResult<GetSocialByIdQueryResult>>;


}
