
namespace MyBlogWebsite.Models.Concrete
{
    public class Article 
    {
		public string Id { get; set; }
		public string ArticleTitle { get; set; }
		public int? TotalReadCount { get; set; } // En çok okunan makaleler kısmı gösterilmeli, bazı makalelerin değerini yüksek ver.
		public int? RequiredMinuteToReadEntireArticle { get; set; }
		public DateTime? PublishDate { get; set; } = DateTime.Now;
		public string? ArticleLength { get; set; } // BaseEntity'den gelen Name, Title olarak değerlendirilecektir. ArticleLength, içeriktir.


		// Navigations
		public string? AuthorId { get; set; }
		public Author Author { get; set; }
		

	}
}
