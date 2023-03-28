using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IProductService
    {
        List<Product> GetAllByStoreId(Guid storeId);
        bool DeleteProduct(Guid storeId);
        bool CreateProduct(Product product);
        bool UpdateTrackedProduct(Product product);
        Product GetProductById(Guid productId);
    }
}
