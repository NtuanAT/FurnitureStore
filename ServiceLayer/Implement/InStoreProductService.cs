using DataLayer.Entities;
using DataLayer.Repository.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implement
{
	public class InstoreProductService : IInstoreProductService
	{
		IInStoreProductRepository _repository;
		public InstoreProductService(IInStoreProductRepository repository)
		{
			_repository = repository;
		}

		public List<InStoreProduct> GetInStoreProducts(Guid storeID)
		{
			return _repository.GetAllProductInPlace(storeID);
		}

		public bool Transfer(Guid warehouseProductID, Guid StoreProductID, int quantity)
		{
			_repository.UpdateAmount(warehouseProductID, quantity*(-1));
			_repository.UpdateAmount(StoreProductID, quantity);

			return true;
		}
	}
}
