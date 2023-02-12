using Microsoft.EntityFrameworkCore;
using MyBlogWebsite.Areas.Identity.Data;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract;
using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete
{
	public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
	{
		private readonly BlogWebsiteDbContext db;
		public AuthorRepository(BlogWebsiteDbContext db) : base(db)
		{
			this.db = db;
		}

		public Author AuthorGetByStringId(string id)
		{
			return db.Authors.Where(x => x.ApplicationUserId == id).FirstOrDefault();
		}

		public bool RemoveCategory(int authorId, int categoryId)
		{
				var author = db.Authors.Include(a => a.FavoryCategories).FirstOrDefault(x => x.Id == authorId);

			if (author != null)
			{
				var favouriteCategoryToRemove = author.FavoryCategories.FirstOrDefault(x => x.Id == categoryId);

				if (favouriteCategoryToRemove != null)
				{
					author.FavoryCategories.Remove(favouriteCategoryToRemove);
					
				}
			}

			return db.SaveChanges() > 0;


		}

	}
}
