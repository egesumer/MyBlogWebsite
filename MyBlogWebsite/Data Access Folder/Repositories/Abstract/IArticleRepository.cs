using MyBlogWebsite.Models.Concrete;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Abstract
{
	public interface IArticleRepository : IRepository<Article>
	{
		List<Article> MostPopularArticles();

		List<Article> GetArticlesWithDesiredCategory(int id);

		List<Article> GetUsersFavouriteArticles(int authorId);

	}
}
