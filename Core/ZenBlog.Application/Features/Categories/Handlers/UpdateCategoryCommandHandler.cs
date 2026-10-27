using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Categories.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Categories.Handlers;

public class UpdateCategoryCommandHandler(IRepository<Category> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
{
    public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        _repository.UpdateAsync(category);
        var response = await _unitOfWork.SaveChangesAsync();

        return response ? BaseResult<bool>.Success(response) : BaseResult<bool>.Fail("Category couldn't bo updated");

    }
}

