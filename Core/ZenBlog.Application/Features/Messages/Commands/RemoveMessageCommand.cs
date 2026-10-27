using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Messages.Commands
{
    public record RemoveMessageCommand(Guid Id) : IRequest<BaseResult<object>>
    {
    }
}
