using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers;

public class GetMessagesQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetMessagesQuery, BaseResult<List<GetMessagesQueryResult>>>
{
    public async Task<BaseResult<List<GetMessagesQueryResult>>> Handle(GetMessagesQuery request, CancellationToken cancellationToken)
    {
        var messages = await _repository.GetAllAsync();
        var result = _mapper.Map<List<GetMessagesQueryResult>>(messages);
        return BaseResult<List<GetMessagesQueryResult>>.Success(result);
    }
}
