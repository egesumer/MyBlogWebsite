using MyBlogWebsite.Areas.Identity.Data;
using MyBlogWebsite.Data_Access_Folder.Repositories.Abstract;
using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Data_Access_Folder.Repositories.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly BlogWebsiteDbContext db;
        public CategoryRepository(BlogWebsiteDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<Category> GetCategories()
        {
          return db.Categories.ToList();
        }
    }
}
