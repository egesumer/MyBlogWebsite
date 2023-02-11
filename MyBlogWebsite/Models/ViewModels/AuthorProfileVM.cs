using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Models.ViewModels
{
	public class AuthorProfileVM
	{
		//public IFormFile Photo { get; set; } veya byte[] alınabilir araştır

		public string AuthorName { get; set; }
		public IEnumerable<Article> Articles { get; set; }
		//public string AboutMe { get; set; }
		// ilgilendiği konular.
	}
}
