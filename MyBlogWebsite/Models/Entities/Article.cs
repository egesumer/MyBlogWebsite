
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.Concrete
{
    public class Article : BaseEntity
    {

		public string ArticleTitle { get; set; }
		public int? TotalReadCount { get; set; } 
		public int? RequiredMinuteToReadEntireArticle { get; set; }
		public DateTime? PublishDate { get; set; } = DateTime.Now;
		public string Content { get; set; } 


		// Navigations
		public int AuthorId { get; set; }
		public Author Author { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}
