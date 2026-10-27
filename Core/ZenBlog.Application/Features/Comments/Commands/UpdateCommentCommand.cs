using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands;

public record UpdateCommentCommand : IRequest<BaseResult<object>>
{
    public Guid Id { get; set; }
    public string UserId { get; init; }
    public string Body { get; init; }
    public Guid BlogId { get; init; }
}
