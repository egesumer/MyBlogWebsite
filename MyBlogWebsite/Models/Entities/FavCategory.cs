using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Models.Entities
{
    public class FavCategory : BaseEntity
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
