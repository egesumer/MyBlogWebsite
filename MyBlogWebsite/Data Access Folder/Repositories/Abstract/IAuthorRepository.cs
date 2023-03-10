using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract
{
	public interface IAuthorRepository:IRepository<Author>
	{
		Author AuthorGetByStringId(string id);

		bool RemoveCategory(int authorId, int categoryId);

    }
}
