using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Comments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Comments.Handlers;

public class UpdateCommentCommandHandler(IRepository<Comment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
{
    public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request);
        _repository.UpdateAsync(comment);
        await _unitOfWork.SaveChangesAsync();
        return BaseResult<object>.Success("Comment Updated Successfully");
    }
}
