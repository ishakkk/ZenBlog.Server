using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers;

public class GetBlogsQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
{
    public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.GetAllAsync();
        var result = _mapper.Map<List<GetBlogsQueryResult>>(blogs);
        return BaseResult<List<GetBlogsQueryResult>>.Success(result);
    }
}
