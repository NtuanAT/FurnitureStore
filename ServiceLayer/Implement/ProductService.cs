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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllByStoreId(Guid storeId)
		{
            List<Product> products = _productRepository.GetAll();
            return products;
            
		}

        public Product GetProductById(Guid productId)
        {
            return _productRepository.Get(p => p.ProductID.Equals(productId));
        }

        public bool UpdateTrackedProduct(Product product)
        {
            return _productRepository.UpdateTrackedEntity<Product>(product);
        }
        public bool CreateProduct(Product product)
        {
            return _productRepository.Create(product);
        }
        public bool DeleteProduct(Guid productId)
        {
            return _productRepository.Delete(p => p.ProductID.Equals(productId));
        }

    }
}
