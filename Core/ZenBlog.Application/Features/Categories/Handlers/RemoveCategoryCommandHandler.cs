using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.id);
            _repository.DeleteAsync(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<bool>.Success(result) : BaseResult<bool>.Fail("Category couldn't bo removed");
        }
    }
}
