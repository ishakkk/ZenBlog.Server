using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Messages.Result;

namespace ZenBlog.Application.Features.Messages.Queries
{
    public record GetMessageByIdQuery(Guid Id) : IRequest<BaseResult<GetMessageByIdQueryResult>>;


}
