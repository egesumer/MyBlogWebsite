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
	}
}
