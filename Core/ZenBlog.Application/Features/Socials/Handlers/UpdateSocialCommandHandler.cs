using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class UpdateSocialCommandHandler(IRepository<Social> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetByIdAsync(request.Id);
            if (social is null)
            {
                return BaseResult<object>.NotFound("Social Not Found");

            }
            var result = _mapper.Map<Social>(social);
            _repository.UpdateAsync(result);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Social is Updated Successfuly");
        }
    }
}
