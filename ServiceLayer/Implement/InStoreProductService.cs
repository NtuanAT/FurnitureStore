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

		public List<InStoreProduct> GetAllProductsInStore(Guid storeId)
		{
			List<InStoreProduct> inStoreProducts = _inStoreProductRepository.GetAllWithRelative();
			return inStoreProducts.Where(x => x.StoreID == storeId).ToList();
		}
	}
}
