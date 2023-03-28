using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public interface IWareHouseRepository : IRepositoryBase<Warehouse>
	{
		List<Warehouse> GetAll();
		Warehouse GetByID(Guid id);
		bool UpdateProductQuantityy(Product type, int quantity);
	}
}
