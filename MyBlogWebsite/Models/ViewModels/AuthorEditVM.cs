using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class AuthorEditVM
	{
		public string AuthorName { get; set; }
		public string AboutMe { get; set; }

		public int FavCategoryId { get; set; }
		public IEnumerable<Category>? FavCategories { get; set; }

	}
}
