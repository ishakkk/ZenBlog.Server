using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class GetContactInfosByIdQueryHandler(IRepository<ContactInfo> _repository, IMapper _mapper) : IRequestHandler<GetContactInfosByIdQuery, BaseResult<GetContactInfosByIdQueryResult>>
{
    public async Task<BaseResult<GetContactInfosByIdQueryResult>> Handle(GetContactInfosByIdQuery request, CancellationToken cancellationToken)
    {
        var contactInfo = await _repository.GetByIdAsync(request.Id);
        if (contactInfo is null)
        {
            return BaseResult<GetContactInfosByIdQueryResult>.NotFound("Contact Info Not Found");

        }
        var result = _mapper.Map<GetContactInfosByIdQueryResult>(contactInfo);
        return BaseResult<GetContactInfosByIdQueryResult>.Success(result);
    }
}
