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
	public class InStoreProductService : IInstoreProductService
	{
		private readonly IInStoreProductRepository _inStoreProductRepository;
		public InStoreProductService(IInStoreProductRepository inStoreProductRepository)
		{
			_inStoreProductRepository = inStoreProductRepository;
		}

		public int Count()
		{
			return _inStoreProductRepository.Count();
		}

		public List<InStoreProduct> GetInStoreProductWithIncludeAndPaging(int pageSize, int pageIndex)
		{
			return _inStoreProductRepository.GetInStoreProductWithPagingAndInclude(pageSize, pageIndex);
		}
	}
}
