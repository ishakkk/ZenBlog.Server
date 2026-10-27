using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.ContactInfos.Result;

namespace ZenBlog.Application.Features.ContactInfos.Queries;

public record GetContactInfosByIdQuery(Guid Id) : IRequest<BaseResult<GetContactInfosByIdQueryResult>>;

