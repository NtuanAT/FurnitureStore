using DataLayer.Entities;
using ServiceLayer.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
	public interface IWareHouseService
	{
		List<WareHouseServiceModel> GetAll();
		Warehouse GetByID(Guid id);
		bool UpdateProductQuantityy(Product type, int quantity);
		bool DeleteWarehouse(Guid warehouseId);
		bool UpdateWarehouse(WareHouseServiceModel model);
		bool AddWarehouse(WareHouseServiceModel model);
	}
}
