using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class RemoveSubCommentCommandHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await _repository.GetByIdAsync(request.Id);

            if (subComment is null)
            {
                return BaseResult<object>.Fail("Sub Commend not found");
            }

            _repository.DeleteAsync(subComment);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Sub Commend is deleted successfuly");
        }
    }
}
