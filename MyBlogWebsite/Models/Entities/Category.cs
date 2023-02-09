using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Models.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }
        public string CategoryName { get; set; }

        // Navigation
        public ICollection<Article> Articles { get; set; }
    }
}
