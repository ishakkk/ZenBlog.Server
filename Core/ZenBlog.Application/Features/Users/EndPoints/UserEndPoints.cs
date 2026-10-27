using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Application.Features.Users.Queries;

namespace ZenBlog.Application.Features.Users.EndPoints
{
    public static class UserEndPoints
    {
        public static void RegisterUserEndPoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users").AllowAnonymous();//Koruma altına almıyoruz
            //var users = app.MapGroup("/users").WithTags("Users");

            users.MapPost("register", async (IMediator _mediatR, CreateUserCommand command) =>
            {
                var response = await _mediatR.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

            users.MapPost("login", async (IMediator _mediatR, GetLoginQuery query) =>
            {
                var response = await _mediatR.Send(query);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
