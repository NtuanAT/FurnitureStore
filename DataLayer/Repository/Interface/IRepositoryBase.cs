using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public interface IRepositoryBase<T> where T : class
	{
		public T Get(Expression<Func<T, bool>> predicate);
		public bool Delete(Expression<Func<T, bool>> predicate);
		public bool Update(T entity);
		public List<T> GetAll();
		public bool Create(T entity);
		public bool UpdateTrackedEntity<T>(T entity);

    }
		
}
