using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class UpdateBlogCommandHandler(IRepository<Blog> _repository, IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Blog>(request);
            _repository.UpdateAsync(blog);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog Has Been Updated Successfully");
        }
    }
}
