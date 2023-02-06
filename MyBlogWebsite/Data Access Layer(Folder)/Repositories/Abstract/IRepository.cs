using System.Linq.Expressions;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetByID(int id);
		bool Add(T entity);
		bool Update(T entity);
		bool Delete(T entity);
		IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
		T SingleOrDefault(Expression<Func<T, bool>> predicate);
	}
}
