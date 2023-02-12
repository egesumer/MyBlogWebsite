using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class AuthorProfileVM
	{
		//public IFormFile Photo { get; set; } veya byte[] 
		public string AboutMe { get; set; }
		public string AuthorName { get; set; }
		public IEnumerable<Article> Articles { get; set; }

		public IEnumerable<Category> FavouriteCategories { get; set; }
	}
}
