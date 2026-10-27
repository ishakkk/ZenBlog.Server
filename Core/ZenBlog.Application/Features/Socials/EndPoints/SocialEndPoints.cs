using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Application.Features.Socials.Queries;

namespace ZenBlog.Application.Features.Socials.EndPoints
{
    public static class SocialEndPoints
    {
        public static void RegisterSocialEndPoints(this IEndpointRouteBuilder app)
        {
            var socials = app.MapGroup("/socials").WithTags("Socials");

            socials.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var result = await _mediator.Send(new GetSocialQuery());
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapGet("{id}", async (IMediator _mediator, Guid id) =>
            {
                var result = await _mediator.Send(new GetSocialByIdQuery(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapPost(string.Empty, async (IMediator _mediatR, CreateSocialCommand command) =>
            {
                var result = await _mediatR.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapDelete("{id}", async (IMediator _mediatR, Guid id) =>
            {
                var result = await _mediatR.Send(new RemoveSocialCommand(id));
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });

            socials.MapPut(string.Empty, async (IMediator _mediatR, UpdateSocialCommand command) =>
            {
                var result = await _mediatR.Send(command);
                return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
            });
        }
    }
}
