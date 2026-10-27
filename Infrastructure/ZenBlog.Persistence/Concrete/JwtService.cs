using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZenBlog.Application.Contracts;
using ZenBlog.Application.Features.Users.Result;
using ZenBlog.Application.Options;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Persistence.Concrete;

public class JwtService(UserManager<AppUser> _userManager, IOptions<JwtTokenOptions> tokenOptions) : IJwtService
{
    private readonly JwtTokenOptions _jwtTokenoptions = tokenOptions.Value;
    public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
    {
        var user = await _userManager.FindByNameAsync(result.UserName);
        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_jwtTokenoptions.Key));
        var dateTimeNow = DateTime.UtcNow;
        List<Claim> claims = new()
        {
            new(JwtRegisteredClaimNames.Name,user.UserName),
            new(JwtRegisteredClaimNames.Sub,user.Id),
            new(JwtRegisteredClaimNames.Email,user.Email),
            new("fullName",string.Join(" ",user.FirstName,user.LastName))
        };

        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtTokenoptions.Issuer,
            audience: _jwtTokenoptions.Audience,
            claims: claims,
            notBefore: dateTimeNow,
            expires: dateTimeNow.AddMinutes(_jwtTokenoptions.ExpireInMinutes),
            signingCredentials: new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            );

        GetLoginQueryResult response = new();
        response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.ExpirationTime = dateTimeNow.AddMinutes(_jwtTokenoptions.ExpireInMinutes);
        return response;

    }
}
