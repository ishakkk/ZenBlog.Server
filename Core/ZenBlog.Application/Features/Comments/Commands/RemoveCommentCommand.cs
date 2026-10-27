using MediatR;
using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Comments.Commands;

public record RemoveCommentCommand(Guid id) : IRequest<BaseResult<object>>;