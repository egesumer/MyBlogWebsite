using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class AuthorEditVM
	{
		public int Id { get; set; }
		public string AuthorName { get; set; }
		public string AboutMe { get; set; }
		//public int FavouriteCategoriesId { get; set; }
		//public IEnumerable<Category> FavouriteCategory { get; set; }

	}
}
