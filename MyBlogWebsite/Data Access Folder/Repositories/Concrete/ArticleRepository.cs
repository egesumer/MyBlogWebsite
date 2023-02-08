using MyBlogWebsite.Areas.Identity.Data;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete
{
	public class ArticleRepository : GenericRepository<Article>, IArticleRepository
	{
		private readonly BlogWebsiteDbContext db;
		public ArticleRepository(BlogWebsiteDbContext db) : base(db) 
		{
			this.db = db;
		}

        public List<Article> MostPopularArticles()
        {
			return db.Articles.OrderByDescending(x => x.TotalReadCount).Take(3).ToList();
        }
    }
}
