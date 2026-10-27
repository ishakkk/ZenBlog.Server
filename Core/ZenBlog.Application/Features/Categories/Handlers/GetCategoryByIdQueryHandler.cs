using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Queries;
using ZenBlog.Application.Features.Categories.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> _repository, IMapper _mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.id);
            if (category == null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound("Category Not Found");

            }
            var respose = _mapper.Map<GetCategoryByIdQueryResult>(category);

            return BaseResult<GetCategoryByIdQueryResult>.Success(respose);
        }
    }
}
