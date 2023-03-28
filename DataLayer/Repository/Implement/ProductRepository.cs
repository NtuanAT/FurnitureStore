using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class ProductRepository : RepositoryBase<Product>
	{
		public ProductRepository(StoreDBContext context) : base(context)
		{
		}
	}
}
