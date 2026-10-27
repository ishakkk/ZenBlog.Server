using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Queries;
using ZenBlog.Application.Features.SubComments.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers;

public class GetSubCommentQueryHandler(IRepository<SubComment> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetSubCommentQuery, BaseResult<List<GetSubCommentQueryResult>>>
{
    public async Task<BaseResult<List<GetSubCommentQueryResult>>> Handle(GetSubCommentQuery request, CancellationToken cancellationToken)
    {
        var subcomments = await _repository.GetAllAsync();
        var result = _mapper.Map<List<GetSubCommentQueryResult>>(subcomments);

        return BaseResult<List<GetSubCommentQueryResult>>.Success(result);

    }
}
