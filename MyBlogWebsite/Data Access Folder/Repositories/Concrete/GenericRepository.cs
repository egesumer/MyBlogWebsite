using MyBlogWebsite.Areas.Identity.Data;
using MyBlogWebsite.Models.Entities;
using System.Linq.Expressions;

namespace MyBlogWebsite.Data_Access_Layer_Folder_.Repositories.Concrete
{
	public class GenericRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly BlogWebsiteDbContext db;

		public GenericRepository(BlogWebsiteDbContext db)
		{
			this.db = db;
		}

		public bool Add(T entity)
		{
			try
			{
				db.Set<T>().Add(entity);
				return db.SaveChanges() > 0;
			}
			catch
			{
				return false; ;
			}
		}

		public bool Delete(T entity)
		{
			try
			{
				db.Set<T>().Remove(entity); 
				return db.SaveChanges() > 0;
			}
			catch
			{

				return false;
			}
		}

		public IEnumerable<T> GetAll()
		{
			return db.Set<T>();
		}

		public T GetByID(int id)
		{
			return db.Set<T>().FirstOrDefault(x=> x.Id == id);	
		}


		public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
		{
			return db.Set<T>().Where(predicate);
		}

		public T SingleOrDefault(Expression<Func<T, bool>> predicate)
		{
			return db.Set<T>().SingleOrDefault(predicate);
		}

		public bool Update(T entity)
		{
			try
			{
				//Update metodu içine gönderilen entity'de id varsa ilgili id'ye sahip entity'yi update eder, id yok ise add gibi çalışır. Bu sebeple tek bir AddOrUpdate metodu da kullanılabilir
				db.Set<T>().Update(entity);
				return db.SaveChanges() > 0;
			}
			catch
			{
				return false;
			}
		}
	}
}
