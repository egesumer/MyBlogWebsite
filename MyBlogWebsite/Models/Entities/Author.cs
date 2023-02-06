

using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.Concrete
{
    public class Author : BaseEntity
    {
        //public int Id { get; set; } //string?

		public string AuthorName { get; set; }
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        // Navigations
        public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public ICollection<Article> Articles { get; set; }
    }
}
