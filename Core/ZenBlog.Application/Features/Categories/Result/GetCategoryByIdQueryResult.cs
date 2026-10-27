using ZenBlog.Application.Base;

namespace ZenBlog.Application.Features.Categories.Result;

public class GetCategoryByIdQueryResult : BaseDto
{
    public string CategoryName { get; set; }
}
