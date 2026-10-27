using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class UpdateContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactinfo = await _repository.GetByIdAsync(request.Id);
        if (contactinfo is null)
        {
            return BaseResult<object>.NotFound("Contact Info Not Found");

        }

        _mapper.Map(request, contactinfo);
        _repository.UpdateAsync(contactinfo);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Contact Info Updated Successfuly");
    }
}
