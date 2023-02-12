using MyBlogWebsite.Areas.Identity.Data;
using MyBlogWebsite.Data_Access_Folder.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Data_Access_Folder.Repositories.Concrete
{
    public class FavCategoryRepository : GenericRepository<FavCategory>, IFavCategoryRepository
    {
        private readonly BlogWebsiteDbContext db;

        public FavCategoryRepository(BlogWebsiteDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
