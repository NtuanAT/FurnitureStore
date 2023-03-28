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
		List<InStoreProduct> GetAllProductInPlace(Guid placeID);
		bool UpdateAmount(Guid id, int amount);

	}
}
