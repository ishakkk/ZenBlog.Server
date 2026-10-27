using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.SubComments.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.SubComments.Handlers
{
    public class CreateSubCommentsCommandHandler(IRepository<SubComment> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateSubCommentsCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSubCommentsCommand request, CancellationToken cancellationToken)
        {
            var subcomment = _mapper.Map<SubComment>(request);
            await _repository.CreateAsync(subcomment);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Sub Commend is inserted");
        }
    }
}
