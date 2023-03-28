using DataLayer.Entities;
using DataLayer.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class WareHouseRepository : RepositoryBase<Warehouse>, IWareHouseRepository
	{
		public WareHouseRepository(StoreDBContext context) : base(context)
		{
		}

		public List<Warehouse> GetAll()
		{
			return _dbSet.ToList();
		}

		public Warehouse GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool UpdateProductQuantityy(Product type, int quantity)
		{
			throw new NotImplementedException();
		}
	}
}
