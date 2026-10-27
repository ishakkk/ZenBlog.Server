using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Socials.Commands
{
    public record RemoveSocialCommand(Guid id) : IRequest<BaseResult<object>>;
}
