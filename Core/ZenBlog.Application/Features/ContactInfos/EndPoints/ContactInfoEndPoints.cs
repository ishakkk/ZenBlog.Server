using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Application.Features.ContactInfos.Queries;

namespace ZenBlog.Application.Features.ContactInfos.EndPoints;

public static class ContactInfoEndPoints
{
    public static void RegisterContactInfoEndPoints(this IEndpointRouteBuilder app)
    {
        var contactinfos = app.MapGroup("/contactinfos").WithTags("ContactInfos");

        contactinfos.MapGet(string.Empty, async (IMediator _mediatR) =>
        {
            var result = await _mediatR.Send(new GetContactInfosQuery());
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        contactinfos.MapGet("{id}", async (IMediator _mediatR, Guid id) =>
        {
            var result = await _mediatR.Send(new GetContactInfosByIdQuery(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        contactinfos.MapPost(string.Empty, async (IMediator _mediatR, CreateContactInfoCommand command) =>
        {
            var result = await _mediatR.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        contactinfos.MapDelete("{id}", async (IMediator _mediatR, Guid id) =>
        {
            var result = await _mediatR.Send(new RemoveContactInfoCommand(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        contactinfos.MapPut(string.Empty, async (IMediator _mediatR, UpdateContactInfoCommand command) =>
        {
            var result = await _mediatR.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });
    }
}
