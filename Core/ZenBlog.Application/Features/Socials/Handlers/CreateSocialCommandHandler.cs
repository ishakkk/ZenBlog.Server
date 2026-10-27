using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class CreateSocialCommandHandler(IRepository<Social> _repository, IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            var social = _mapper.Map<Social>(request);
            await _repository.CreateAsync(social);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social is inserted");
        }
    }
}
