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
        private StoreDBContext _storeDBContext;
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
        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            _dbSet.Remove(Get(predicate));
            return _storeDBContext.SaveChanges()>0;
        }
        public bool Update(T entity)
        {
			_dbSet.Attach(entity);
            _storeDBContext.Entry(entity).State = EntityState.Modified;
            return _storeDBContext.SaveChanges()>0;
        }

        public bool UpdateTrackedEntity<T>(T entity)
        {
            var entityType = _storeDBContext.Model.FindEntityType(typeof(T));
            var primaryKey = entityType.FindPrimaryKey();
            var primaryKeyPropertyName = primaryKey.Properties.First().Name; // Only work with table have 1 primary key, could change it to get 2 different primary key name

            var existingEntity = _dbSet.Local.FirstOrDefault(e => _storeDBContext.Entry(e).Property(primaryKeyPropertyName).CurrentValue.Equals(_storeDBContext.Entry(entity).Property(primaryKeyPropertyName).CurrentValue));

            if (existingEntity != null)
            {
                _storeDBContext.Entry(existingEntity).State = EntityState.Detached;
            }

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
