using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T:class 
    {
        protected StoreDBContext _storeDBContext;
        protected DbSet<T> _dbSet { get; set; }
        
        public RepositoryBase(StoreDBContext context)
        {
            _storeDBContext = context;
			_dbSet = _storeDBContext.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var objectToremove = _dbSet.Where(predicate).FirstOrDefault();
            if (objectToremove != null)
            {
                _dbSet.Remove(objectToremove);
            }
            _storeDBContext.SaveChanges();
        }
        public bool Update(T entity)
        {
			_dbSet.Attach(entity);
            _storeDBContext.Entry(entity).State = EntityState.Modified;
            return _storeDBContext.SaveChanges()>0;
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public bool Create(T entity)
        {
			_dbSet.Add(entity);
            return _storeDBContext.SaveChanges() > 0;
        }

    }
}
