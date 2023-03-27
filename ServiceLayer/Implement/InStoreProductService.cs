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
	public class InStoreProductService : IInStoreProductService
	{
		private readonly IInStoreProductRepository _inStoreProductRepository;
        public InStoreProductService(IInStoreProductRepository inStoreProductRepository)
        {
			_inStoreProductRepository = inStoreProductRepository;
        }

        public bool DeActivateProductInStore(InStoreProduct inStoreProduct)
        {
            return _inStoreProductRepository.DeActivateProductInStore(inStoreProduct);
        }

        public List<InStoreProduct> GetAllProductsInStore(Guid storeId)
		{
			List<InStoreProduct> inStoreProducts = _inStoreProductRepository.GetAllWithRelative();
			return inStoreProducts.Where(x => x.StoreID == storeId).ToList();
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
