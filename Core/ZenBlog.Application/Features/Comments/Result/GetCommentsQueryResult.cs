using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Features.Comments.Result;

public class GetCommentsQueryResult : BaseDto
{
    public string UserId { get; set; }

    public GetUsersQueryResult User { get; set; }
    public string Body { get; set; }
    public DateTime CommentDate { get; set; }
    // public virtual IList<SubComment> SubComments { get; set; }
    public Guid BlogId { get; set; }
    public GetBlogsQueryResult Blog { get; set; }
}
