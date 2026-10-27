using ZenBlog.Application.Features.Users.Result;

namespace ZenBlog.Application.Contracts;

public interface IJwtService
{
    Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result);
}
