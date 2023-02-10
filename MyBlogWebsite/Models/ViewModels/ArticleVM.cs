using Microsoft.Build.Framework;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Models.ViewModels
{
    public class ArticleVM
    {
        public string ArticleTitle { get; set; }
        public string Content { get; set; }
        public int TotalReadCount { get; set; }

        public string AuthorName { get; set; }
        public int RequiredMinsToRead { get; set; }
        public DateTime PublishDate { get; set; }

        public IFormFile Image { get; set; }
    }
}
