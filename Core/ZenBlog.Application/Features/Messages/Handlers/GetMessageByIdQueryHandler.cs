using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Messages.Queries;
using ZenBlog.Application.Features.Messages.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Messages.Handlers
{
    public class GetMessageByIdQueryHandler(IRepository<Message> _repository, IMapper _mapper) : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageByIdQueryResult>>
    {
        public async Task<BaseResult<GetMessageByIdQueryResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var message = await _repository.GetByIdAsync(request.Id);
            if (message is null)
            {
                return BaseResult<GetMessageByIdQueryResult>.NotFound("Message Not Found");

            }
            var result = _mapper.Map<GetMessageByIdQueryResult>(message);

            return BaseResult<GetMessageByIdQueryResult>.Success(result);
        }
    }
}
