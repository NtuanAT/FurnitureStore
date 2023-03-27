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
        
        public bool DeActivateProductInStore(InStoreProduct inStoreProduct)
        {
            var updateRecord = _dbSet.Find(inStoreProduct.InStoreProductID);
            if (updateRecord != null)
            {
                if (updateRecord.Status == ProductStatus.Active)
                {
                    updateRecord.Status = ProductStatus.InActive;
                    return Update(updateRecord);
                }
                else
                {
                    // Product is already inactive
                    return false;
                }
            }
            else
            {
                // Record not found
                return false;
            }
        }

        public List<InStoreProduct> GetAllWithRelative()
		{
			return _dbSet.Include(i=>i.Product).Include(i=>i.Store).ToList();
		}

        public InStoreProduct GetByIdWithRelative(Guid productId)
        {
            return _dbSet.Where(p => p.InStoreProductID.Equals(productId)).Include(i => i.Product).Include(i => i.Store).FirstOrDefault();
        }
    }
}
