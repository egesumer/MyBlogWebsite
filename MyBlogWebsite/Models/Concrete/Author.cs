

namespace MyBlogWebsite.Models.Concrete
{
    public class Author 
    {
        public string Id { get; set; }

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
