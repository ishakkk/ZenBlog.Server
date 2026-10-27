using ZenBlog.Application.Features.Blogs.EndPoints;
using ZenBlog.Application.Features.Categories.EndPoints;
using ZenBlog.Application.Features.Comments.EndPoints;
using ZenBlog.Application.Features.ContactInfos.EndPoints;
using ZenBlog.Application.Features.Messages.EndPoints;
using ZenBlog.Application.Features.SubComments.EndPoints;
using ZenBlog.Application.Features.Users.EndPoints;

namespace ZenBlog.WebApi.EndPoints.Registration
{
    public static class EndPointRegistrations
    {
        public static void RegisterEndPoints(this IEndpointRouteBuilder app)
        {
            app.RegisterCategoryEndPoint();
            app.RegisterBlogEndPoints();
            app.RegisterUserEndPoints();
            app.RegisterCommentEndPoints();
            app.ResgisterSubCommentEndPoints();
            app.RegisterContactInfoEndPoints();
            app.RegisterMessageEndPoints();
        }
    }
}
