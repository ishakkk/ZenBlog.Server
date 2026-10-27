using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Application.Features.Comments.Queries;

namespace ZenBlog.Application.Features.Comments.EndPoints
{
    public static class CommentEndPoints
    {
        public static void RegisterCommentEndPoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comments").WithTags("Comments");

            comments.MapGet(string.Empty, async (IMediator _mediatR) =>
            {
                var result = await _mediatR.Send(new GetCommentsQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            comments.MapPost(string.Empty, async (IMediator _mediator, CreateCommentCommand command) =>
            {
                var result = await _mediator.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            comments.MapGet("{id}", async (Guid id, IMediator _mediatR) =>
            {
                var result = await _mediatR.Send(new GetCommentByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
            comments.MapPut(string.Empty, async (IMediator _mediatR, UpdateCommentCommand command) =>
            {
                var result = await _mediatR.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            comments.MapDelete("{id}", async (IMediator _mediatR, Guid id) =>
            {
                var result = await _mediatR.Send(new RemoveCommentCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
