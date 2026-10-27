using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Users.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Users.Handlers;

public class CreateUserCommandHandler(UserManager<AppUser> _userManager, IMapper _mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<AppUser>(request);
        //var user = new AppUser
        //{
        //    FirstName = request.FirstName,
        //    LastName = request.LastName,
        //    Email = request.Email,
        //    UserName = request.UserName
        //};
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return BaseResult<object>.Fail(result.Errors);
        }
        return BaseResult<object>.Success("User Is Created Succesfully");

    }
}
