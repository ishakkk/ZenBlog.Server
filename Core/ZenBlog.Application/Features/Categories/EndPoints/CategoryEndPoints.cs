using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Application.Features.Categories.Queries;

namespace ZenBlog.Application.Features.Categories.EndPoints;

public static class CategoryEndPoints
{
    public static void RegisterCategoryEndPoint(this IEndpointRouteBuilder app)
    {
        var categories = app.MapGroup("/categories").WithTags("Categories");

        categories.MapGet(string.Empty, async (IMediator _mediatR) =>
        {
            var result = await _mediatR.Send(new GetCategoryQuery());
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        categories.MapPost(string.Empty, async (CreateCategoryCommand command, IMediator _mediatR) =>
        {
            var result = await _mediatR.Send(command);
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        categories.MapGet("{id}", async (IMediator _mediatR, Guid id) =>
        {
            var result = await _mediatR.Send(new GetCategoryByIdQuery(id));
            return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
        });

        categories.MapPut(string.Empty, async (IMediator _mediatR, UpdateCategoryCommand command) =>
        {
            var response = await _mediatR.Send(command);
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

        categories.MapDelete("{id}", async (IMediator _mediatR, Guid id) =>
        {
            var response = await _mediatR.Send(new RemoveCategoryCommand(id));
            return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
        });

    }
}
