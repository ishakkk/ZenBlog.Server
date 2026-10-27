using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries;

public record GetBlogsQuery : IRequest<BaseResult<List<GetBlogsQueryResult>>>;

