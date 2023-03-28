using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
	public interface IInStoreProductService
	{
		bool Transfer(Guid warehouseProductID, Guid StoreProductID, int quantity);
        List<InStoreProduct> GetAllProductsInStore(Guid storeId);
        InStoreProduct GetProductInStore(Guid productId);
        bool DeActivateProductInStore(InStoreProduct inStoreProduct);
        bool UpdateTrackedInStoreProduct(InStoreProduct inStoreProduct);
        bool CreateInStoreProduct(InStoreProduct inStoreProduct);
    }
}
