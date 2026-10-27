using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Queries;
using ZenBlog.Application.Features.Comments.Result;
using ZenBlog.Domain.Entities;
namespace ZenBlog.Application.Features.Comments.Handlers;

public class GetCommentByIdQueryHandler(IRepository<Comment> _repository, IMapper _mapper) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
{
    public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await _repository.GetByIdAsync(request.Id);
        if (comment is null)
        {
            return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment Not Found");
        }
        var result = _mapper.Map<GetCommentByIdQueryResult>(comment);
        return BaseResult<GetCommentByIdQueryResult>.Success(result);
    }
}
