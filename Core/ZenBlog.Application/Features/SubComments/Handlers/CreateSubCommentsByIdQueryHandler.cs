using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

public class CreateSubCommentsByIdQueryHandler(IRepository<SubComment> _repository, IMapper _mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdQueryResult>>
{
    public async Task<BaseResult<GetSubCommentByIdQueryResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var subcomment = await _repository.GetByIdAsync(request.id);
        if (subcomment is null)
        {
            return BaseResult<GetSubCommentByIdQueryResult>.NotFound("Sub Comment Not Found");
        }
        var result = _mapper.Map<GetSubCommentByIdQueryResult>(subcomment);
        return BaseResult<GetSubCommentByIdQueryResult>.Success(result);
    }
}
