using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repository.Interface;
using ServiceLayer.Interface;
using ServiceLayer.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implement
{
	public class WareHouseService : IWareHouseService
	{
		IWareHouseRepository _repository;
		IMapper _mapper;
		IInStoreProductRepository _products;

		public WareHouseService(IWareHouseRepository repository, IMapper mapper, IInStoreProductRepository products)
		{
			_repository = repository;
			_mapper = mapper;
			_products = products;
		}

        public bool AddWarehouse(WareHouseServiceModel model)
        {
			var newWarehouse = ManualMap(model);

            return _repository.Create(newWarehouse);
        }

        public bool DeleteWarehouse(Guid warehouseId)
        {
            return _repository.Delete(w => w.WareHouseID.Equals(warehouseId));
        }

        public List<WareHouseServiceModel> GetAll()
		{
			var entites = new List<Warehouse>();
			entites = _repository.GetAll();

			var result = new List<WareHouseServiceModel>();
			foreach (var item in entites)
			{
				WareHouseServiceModel model = ManualMap(item);
				model.products = _products.GetAllProductInPlace(model.WareHouseID);
				result.Add(model);
			}

			return result;
		}

		public Warehouse GetByID(Guid id)
		{
			throw new NotImplementedException();
		}

		public bool UpdateProductQuantityy(Product type, int quantity)
		{
			throw new NotImplementedException();
		}

        public bool UpdateWarehouse(WareHouseServiceModel model)
        {
			var updateWarehouse = ManualMap(model);

            return _repository.Update(updateWarehouse);
        }

        private WareHouseServiceModel ManualMap(Warehouse source)
		{
			WareHouseServiceModel result = new WareHouseServiceModel();
			result.WareHouseID = source.WareHouseID;
			//result.Admin = source.Admin;
			result.Name = source.Name;
			result.Location = source.Location;
			result.products = new List<InStoreProduct>();

			return result;
		}

		private Warehouse ManualMap(WareHouseServiceModel source)
		{
			Warehouse result = new Warehouse();

			result.WareHouseID = source.WareHouseID;
			//result.Admin = source.Admin;
			result.Name = source.Name;
			result.Location = source.Location;

			return result;
		}
	}
}
