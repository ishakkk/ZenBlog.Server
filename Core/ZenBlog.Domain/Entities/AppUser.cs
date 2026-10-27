using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public virtual IList<Blog> Blogs { get; set; }
        public virtual IList<Comment> Comments { get; set; }

        public virtual IList<SubComment> SubComments { get; set; }
    }
}
