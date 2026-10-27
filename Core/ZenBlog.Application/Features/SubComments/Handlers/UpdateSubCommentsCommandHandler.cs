using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

public class UpdateSubCommentsCommandHandler(IRepository<SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateSubCommentsCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateSubCommentsCommand request, CancellationToken cancellationToken)
    {
        var subComment = await _repository.GetByIdAsync(request.Id);

        if (subComment is null)
        {
            return BaseResult<object>.Fail("Sub Commend not found");
        }
        subComment = _mapper.Map<SubComment>(request);
        _repository.UpdateAsync(subComment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Sub Commend is updates successfuly");
    }
}
