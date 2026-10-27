using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.ContactInfos.Queries;
using ZenBlog.Application.Features.ContactInfos.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.ContactInfos.Handlers;

public class GetContactInfosQueryHandler(IRepository<ContactInfo> _repository, IMapper _mapper) : IRequestHandler<GetContactInfosQuery, BaseResult<List<GetContactInfosQueryResult>>>
{
    public async Task<BaseResult<List<GetContactInfosQueryResult>>> Handle(GetContactInfosQuery request, CancellationToken cancellationToken)
    {
        var contactInfos = await _repository.GetAllAsync();
        var result = _mapper.Map<List<GetContactInfosQueryResult>>(contactInfos);
        return BaseResult<List<GetContactInfosQueryResult>>.Success(result);
    }
}
