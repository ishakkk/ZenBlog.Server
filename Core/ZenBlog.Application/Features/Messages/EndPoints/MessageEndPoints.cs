using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Application.Features.Messages.Queries;

namespace ZenBlog.Application.Features.Messages.EndPoints
{
    public static class MessageEndPoints
    {
        public static void RegisterMessageEndPoints(this IEndpointRouteBuilder app)
        {
            var messages = app.MapGroup("/messages").WithTags("Messages");

            messages.MapGet(string.Empty, async (IMediator _mediatR) =>
            {
                var result = await _mediatR.Send(new GetMessagesQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapGet("{id}", async (IMediator _mediatR, Guid id) =>
            {
                var result = await _mediatR.Send(new GetMessageByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapPost(string.Empty, async (IMediator _mediatR, CreateMessageCommand command) =>
            {
                var result = await _mediatR.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapDelete("{id}", async (IMediator _mediatR, Guid id) =>
            {
                var result = await _mediatR.Send(new RemoveMessageCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            messages.MapPut(string.Empty, async (IMediator _mediatR, UpdateMessageCommand command) =>
            {
                var result = await _mediatR.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
