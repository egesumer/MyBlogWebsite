using Microsoft.EntityFrameworkCore;
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

		public List<Article> GetArticlesWithDesiredCategory(int id)
		{
			return db.Articles.Where(x=>x.CategoryId== id).ToList();
		}

		public List<Article> GetUsersFavouriteArticles(int authorId)
		{

			var author = db.Authors.Include(a => a.FavoryCategories).ThenInclude(fc => fc.Articles).FirstOrDefault(a => a.Id == authorId);

			if (author != null)
			{
				var favoriteArticles = author.FavoryCategories.SelectMany(fc => fc.Articles).ToList();

				return favoriteArticles;
			}
			else
			{
				return null;
			}


		}

		public List<Article> MostPopularArticles()
        {
			return db.Articles.OrderByDescending(x => x.TotalReadCount).Take(3).ToList();
        }



    }
}
