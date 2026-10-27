using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers;

public class GetBlogsByCategoryIdQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogsByCategoryIdQuery, BaseResult<List<GetBlogsByCategoryIdQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsByCategoryIdQueryResult>>> Handle(GetBlogsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetQueryAsync();
        var values = query.Where(x => x.CategoryId == request.CategoryId).ToList();
        var blogs = _mapper.Map<List<GetBlogsByCategoryIdQueryResult>>(values);

        return BaseResult<List<GetBlogsByCategoryIdQueryResult>>.Success(blogs);
    }
}
