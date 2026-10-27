using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.SubComments.Commands;

public record UpdateSubCommentsCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; init; }
    public string UserId { get; init; }

    public string Body { get; init; }

    public Guid CommentId { get; init; }
}
