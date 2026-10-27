using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class CreateContactInfoCommandHandler(IRepository<ContactInfo> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
    {
        var contactinfo = _mapper.Map<ContactInfo>(request);
        await _repository.CreateAsync(contactinfo);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Contact Info Created Successfuly");
    }
}
