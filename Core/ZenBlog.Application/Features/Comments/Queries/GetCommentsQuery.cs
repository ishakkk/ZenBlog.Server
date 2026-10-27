using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Comments.Result;

namespace ZenBlog.Application.Features.Comments.Queries;

public record GetCommentsQuery : IRequest<BaseResult<List<GetCommentsQueryResult>>>;

