using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class ArticleIndexVM
	{
		public IEnumerable<Article> FavouriteArticles { get; set; }
		public IEnumerable<Article> Articles { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
