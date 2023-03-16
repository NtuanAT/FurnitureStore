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
        public DbSet<T> Set { get; set; }
        public RepositoryBase()
        {
            _storeDBContext = new();
            Set = _storeDBContext.Set<T>();
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate).FirstOrDefault();
        }
        public void Delete(Expression<Func<T, bool>> predicate)
        {

        }
        public bool Update(T entity)
        {
            Set.Attach(entity);
            _storeDBContext.Entry(entity).State = EntityState.Modified;
            return _storeDBContext.SaveChanges()>0;
        }
        public List<T> GetAll()
        {
            return Set.ToList();
        }
        public bool Create(T entity)
        {
            Set.Add(entity);
            return _storeDBContext.SaveChanges() > 0;
        }

    }
}
