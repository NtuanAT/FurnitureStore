using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public interface IInStoreProductRepository : IRepositoryBase<InStoreProduct>
	{
<<<<<<< HEAD
=======
		List<InStoreProduct> GetAllWithRelative();
>>>>>>> parent of a5a02de (Add CRUD for InStoreProduct and Product)
	}
}
