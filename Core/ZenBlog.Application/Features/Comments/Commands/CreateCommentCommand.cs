using MediatR;
using System.Text.Json.Serialization;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands;

public record CreateCommentCommand : IRequest<BaseResult<object>>
{
    public string UserId { get; init; }
    public string Body { get; init; }
    [JsonIgnore]
    public DateTime CommentDate { get; init; } = DateTime.Now;
    public Guid BlogId { get; init; }

}
