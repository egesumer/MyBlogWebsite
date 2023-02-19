using MyBlogWebsite.Data_Access_Layer_Folder_.Repositories;
using MyBlogWebsite.Models.Concrete;
using MyBlogWebsite.Models.Entities;

namespace MyBlogWebsite.Data_Access_Folder.Repositories.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Category> GetCategories();

        List<Category> GetFavouriteCategories(int authorId);

    }
}
