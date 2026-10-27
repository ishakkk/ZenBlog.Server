using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Queries;

public record GetCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetCommentByIdQueryResult>>;

