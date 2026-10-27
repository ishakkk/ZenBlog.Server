using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Domain.Entities;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }
    public virtual IList<Blog> Blogs { get; set; }
}

