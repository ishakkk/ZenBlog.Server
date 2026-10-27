using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Blogs.Result;

namespace ZenBlog.Application.Features.Blogs.Queries;

public record GetBlogsByCategoryIdQuery(Guid CategoryId) : IRequest<BaseResult<List<GetBlogsByCategoryIdQueryResult>>>;

