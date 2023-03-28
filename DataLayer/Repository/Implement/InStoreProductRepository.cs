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

		public List<InStoreProduct> GetAllProductInPlace(Guid placeID)
		{
			return _dbSet.Where(ip => ip.BelongTo.Equals(placeID)).Include(ip => ip.Product).ToList();

		}

		public bool UpdateAmount(Guid id, int amount)
		{
			var result = _dbSet.FirstOrDefault(x => x.InStoreProductID == id);
			if (result == null)
			{
				return false;
			}
			else
			{
				result.Quantity += amount;
				_dbSet.Update(result);
				return _storeDBContext.SaveChanges() > 0;
			}
		}
	}
}
