using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Application.Features.SubComments.Queries;

namespace ZenBlog.Application.Features.SubComments.EndPoints;

public static class SubCommentEndPoints
{
    public static void ResgisterSubCommentEndPoints(this IEndpointRouteBuilder app)
    {
        var subComments = app.MapGroup("/subComments").WithTags("SubComments");

        subComments.MapPost(string.Empty, async (IMediator _mediatR, CreateSubCommentsCommand command) =>
        {
            var result = await _mediatR.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        subComments.MapGet(string.Empty, async (IMediator _mediator) =>
        {
            var result = await _mediator.Send(new GetSubCommentQuery());
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
        subComments.MapGet("{id}", async (IMediator _mediator, Guid id) =>
        {
            var result = await _mediator.Send(new GetSubCommentByIdQuery(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        subComments.MapPut(string.Empty, async (IMediator _mediator, UpdateSubCommentsCommand commad) =>
        {
            var result = await _mediator.Send(commad);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
        subComments.MapDelete("{id}", async (IMediator _mediator, Guid id) =>
        {
            var result = await _mediator.Send(new RemoveSubCommentCommand(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
