using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.SubComments.Result;

public class GetSubCommentByIdQueryResult
{
    public string UserId { get; set; }

    public GetUsersQueryResult User { get; set; }
    public string Body { get; set; }
    public DateTime CommentDate { get; set; }

    public Guid CommentId { get; set; }
    public GetCommentsQueryResult Comment { get; set; }
}
