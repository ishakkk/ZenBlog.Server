using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class RemoveContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactinfo = await _repository.GetByIdAsync(request.Id);
        if (contactinfo is null)
        {
            return BaseResult<object>.NotFound("Contact Info Not Found");

        }
        _repository.DeleteAsync(contactinfo);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Contact Info Deleted Successfuly");
    }
}
