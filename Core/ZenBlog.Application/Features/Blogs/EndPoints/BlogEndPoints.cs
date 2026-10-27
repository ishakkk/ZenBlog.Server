
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Application.Features.Blogs.Queries;

namespace ZenBlog.Application.Features.Blogs.EndPoints;

public static class BlogEndPoints
{
    public static void RegisterBlogEndPoints(this IEndpointRouteBuilder app)
    {
        var blogs = app.MapGroup("/blogs").WithTags("Blogs");

        blogs.MapGet(string.Empty, async (IMediator _mediatR) =>
        {
            var result = await _mediatR.Send(new GetBlogsQuery());
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);

        });

        blogs.MapPost(string.Empty, async (IMediator _mediatR, CreateBlogCommand command) =>
        {
            var result = await _mediatR.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        blogs.MapGet("{id}", async (IMediator _mediatR, Guid id) =>
        {
            var result = await _mediatR.Send(new GetBlogsByIdQuery(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        blogs.MapPut(string.Empty, async (IMediator mediator, UpdateBlogCommand command) =>
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
        blogs.MapDelete("{id}", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new RemoveBlogCommand(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
        blogs.MapGet("byCategoryId/{cagegoryId}", async (Guid cagegoryId, IMediator _mediatR) =>
            {
                var result = await _mediatR.Send(new GetBlogsByCategoryIdQuery(cagegoryId));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
    }
}
