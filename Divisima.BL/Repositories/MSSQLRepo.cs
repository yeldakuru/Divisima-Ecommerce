using Divisima.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Divisima.BL.Repositories
{
	public class MSSQLRepo<T> where T : class
	{
		MSSQLDbContext db;
        public MSSQLRepo(MSSQLDbContext _db)
        {
            db = _db;
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

		public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
		{
			return db.Set<T>().Where(expression);
		}

		public T GetBy(Expression<Func<T, bool>> expression)
		{
			return db.Set<T>().FirstOrDefault(expression);
		}

        public T GetByAsNoTracking(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().AsNoTracking().FirstOrDefault(expression);
        }
        public void Add(T model)
		{
			db.Set<T>().Add(model);
			db.SaveChanges();
		}

		public void Delete(T model)
		{
			db.Set<T>().Remove(model);
			db.SaveChanges();
		}

		public void Update(T model)
		{
			db.Set<T>().Update(model);
			db.SaveChanges();
		}
	}
}
