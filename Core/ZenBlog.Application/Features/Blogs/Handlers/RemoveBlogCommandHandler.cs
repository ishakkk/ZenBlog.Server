using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Blogs.Commands;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Blogs.Handlers
{
    public class RemoveBlogCommandHandler(IRepository<Blog> _repository, IUnitOfWork _unitOfWork) : IRequestHandler<RemoveBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.id);
            if (blog == null)
            {
                return BaseResult<object>.NotFound("Blog Not Found");
            }

            _repository.DeleteAsync(blog);
            await _unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success("Blog Has Been Deleted Succesfully");
        }
    }
}
