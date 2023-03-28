using DataLayer.Entities;
using DataLayer.Repository.Implement;
using DataLayer.Repository.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implement
{
	public class InstoreProductService : IInStoreProductService
	{
		IInStoreProductRepository _inStoreProductRepository;
		public InstoreProductService(IInStoreProductRepository repository)
		{
			_inStoreProductRepository = repository;
		}

		public List<InStoreProduct> GetInStoreProducts(Guid storeID)
		{
			return _inStoreProductRepository.GetAllProductInPlace(storeID);
		}

		public bool Transfer(Guid warehouseProductID, Guid StoreProductID, int quantity)
		{
			_inStoreProductRepository.UpdateAmount(warehouseProductID, quantity*(-1));
			_inStoreProductRepository.UpdateAmount(StoreProductID, quantity);

			return true;
		}

        public bool DeActivateProductInStore(InStoreProduct inStoreProduct)
        {
            return _inStoreProductRepository.DeActivateProductInStore(inStoreProduct);
        }

        public List<InStoreProduct> GetAllProductsInStore(Guid storeId)
        {
            List<InStoreProduct> inStoreProducts = _inStoreProductRepository.GetAllWithRelative();
            return inStoreProducts.Where(x => x.BelongTo == storeId).ToList();
        }

        public InStoreProduct GetProductInStore(Guid productId)
        {
            return _inStoreProductRepository.GetByIdWithRelative(productId);
        }

        public bool UpdateTrackedInStoreProduct(InStoreProduct inStoreProduct)
        {
            return _inStoreProductRepository.UpdateTrackedEntity<InStoreProduct>(inStoreProduct);
        }

        public bool CreateInStoreProduct(InStoreProduct inStoreProduct)
        {
            return _inStoreProductRepository.Create(inStoreProduct);
        }
    }
}
