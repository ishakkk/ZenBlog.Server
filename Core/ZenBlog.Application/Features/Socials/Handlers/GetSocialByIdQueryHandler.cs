using AutoMapper;
using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Application.Features.Socials.Queries;
using ZenBlog.Application.Features.Socials.Result;
using ZenBlog.Domain.Entities;

namespace ZenBlog.Application.Features.Socials.Handlers
{
    public class GetSocialByIdQueryHandler(IRepository<Social> _repository, IMapper _mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            var social = await _repository.GetByIdAsync(request.Id);
            if (social is null)
            {
                return BaseResult<GetSocialByIdQueryResult>.NotFound("Social Not Found");

            }
            var result = _mapper.Map<GetSocialByIdQueryResult>(social);

            return BaseResult<GetSocialByIdQueryResult>.Success(result);
        }
    }
}
