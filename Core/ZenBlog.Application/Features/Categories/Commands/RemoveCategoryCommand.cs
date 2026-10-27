using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Commands
{
    public record RemoveCategoryCommand(Guid id) : IRequest<BaseResult<bool>>;
}
