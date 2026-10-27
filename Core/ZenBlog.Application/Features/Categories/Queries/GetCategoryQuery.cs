using MediatR;
using ZenBlog.Application.Base;
using ZenBlog.Application.Features.Categories.Result;

namespace ZenBlog.Application.Features.Categories.Queries;

public record GetCategoryQuery : IRequest<BaseResult<List<GetCategoryQueryResult>>>;

