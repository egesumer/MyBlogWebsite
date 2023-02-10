using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
	public class ArticleUpdateVM
	{
		//public IEnumerable<Category>? Categories { get; set; }
		//public int SelectedCategoryId { get; set; }

		public int Id { get; set; }
		public string ArticleTitle { get; set; }
		public string Content { get; set; }
	}
}
