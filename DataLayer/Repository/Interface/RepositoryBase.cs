using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public class RepositoryBase<T> where T : class
	{
		private	StoreDBContext _storeDBContext;
		public DbSet<T> Set { get; set; }
		public RepositoryBase()
		{
			_storeDBContext = new();
			Set = _storeDBContext.Set<T>();
		}
		public T Get(Expression<Func<T,bool>> predicate)
		{
			return Set.Where(predicate).FirstOrDefault();
		}
		public void Delete(Expression<Func<T,bool>> predicate)
		{
			
		}
		public void Update(T entity)
		{
			Set.Attach(entity);
			_storeDBContext.Entry(entity).State = EntityState.Modified;
			_storeDBContext.SaveChanges();
		}
		public List<T> GetAll()
		{
			return Set.ToList();
		}
		public void Create(T entity)
		{
			Set.Add(entity);
			_storeDBContext.SaveChanges();
		}

	}
}
