

using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.Concrete
{
    public class Author : BaseEntity
    {

		public string AuthorName { get; set; }
        public bool AuthorConfirmed { get; set; } = false;


        public string? AboutMe { get; set; }
        public Author()
        {
            Articles = new HashSet<Article>();
           FavoryCategories = new HashSet<Category>();
        }

        // Navigations
        public string ApplicationUserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public ICollection<Article> Articles { get; set; }
        public ICollection<Category> FavoryCategories { get; set; }
    }
}
