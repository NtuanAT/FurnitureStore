using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
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

		public int Count()
		{
			return _dbSet.Where(pr => pr.Status==ProductStatus.Active).Count();
		}

		public List<InStoreProduct> GetInStoreProductWithPagingAndInclude(int pageSize, int pageIndex)
		{
			return _dbSet.Include(ip => ip.Product).Skip(pageSize*(pageIndex - 1)).Take(pageSize).ToList();
		}
	}
}
