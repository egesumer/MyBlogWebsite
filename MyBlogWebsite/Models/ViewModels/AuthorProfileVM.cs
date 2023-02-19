using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class AuthorProfileVM
	{
		public string AboutMe { get; set; }
		public string AuthorName { get; set; }
		public string? Path { get; set; }
		public IEnumerable<Article> FavoryCategoryArticles { get; set; }

		public IEnumerable<Category> FavouriteCategories { get; set; }
	}
}
