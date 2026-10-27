using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class RemoveSocialCommandHandler(IRepository<Social> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSocialCommand request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetByIdAsync(request.id);
            if (social is null)
            {
                return BaseResult<object>.NotFound("Social is not found");
            }

            _repository.DeleteAsync(social);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social is deleted successfuly");
        }
    }
}
