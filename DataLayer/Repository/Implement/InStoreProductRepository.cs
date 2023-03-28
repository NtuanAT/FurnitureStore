using DataLayer.Entities;
using DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class InStoreProductRepository : RepositoryBase<InStoreProduct>, IInStoreProductRepository
	{
		public InStoreProductRepository(StoreDBContext context) : base(context)
		{
		}
<<<<<<< HEAD
=======

		public List<InStoreProduct> GetAllWithRelative()
		{
			return _dbSet.Include(i=>i.Product).Include(i=>i.Store).ToList();
		}
>>>>>>> parent of a5a02de (Add CRUD for InStoreProduct and Product)
	}
}
