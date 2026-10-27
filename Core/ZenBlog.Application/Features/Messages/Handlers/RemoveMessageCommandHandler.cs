using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class RemoveMessageCommandHandler(IRepository<Message> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message is null)
            {
                return BaseResult<object>.NotFound("Message Info Not Found");

            }
            _repository.DeleteAsync(message);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Message Deleted Successfuly");
        }
    }
}
