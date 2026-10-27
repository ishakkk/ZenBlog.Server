using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Queries;
using ZenBlog.Application.Features.Blogs.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IRepository<Blog> _repository, IMapper _mapper) : IRequestHandler<GetBlogsByIdQuery, BaseResult<GetBlogsByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogsByIdQueryResult>> Handle(GetBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.id);
            if (blog is null)
            {
                return BaseResult<GetBlogsByIdQueryResult>.NotFound("Blog Not Found");

            }
            var result = _mapper.Map<GetBlogsByIdQueryResult>(blog);

            return BaseResult<GetBlogsByIdQueryResult>.Success(result);

        }
    }
}
