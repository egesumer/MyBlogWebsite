using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Models.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Articles = new HashSet<Article>();
            Authors= new HashSet<Author>();
        }
        public string CategoryName { get; set; }

        // Navigation
        public ICollection<Article> Articles { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
