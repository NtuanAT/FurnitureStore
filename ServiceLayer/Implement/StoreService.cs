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
    public class StoreService : IStoreService
    {
        private IStoreRepository _storeRepository;
        private IInStoreProductRepository _products;
        private IMapper _mapper;
        public StoreService(IStoreRepository storeRepository, IInStoreProductRepository inStoreProductRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _products = inStoreProductRepository;
            _mapper = mapper;
        }

		public List<StoreServiceModel> GetAll()
		{
			
			var entites = _storeRepository.GetAll();

			var result = new List<StoreServiceModel>();
			foreach (var item in entites)
			{
				StoreServiceModel model = ManualMap(item);
				model.products = _products.GetAllProductInPlace(model.StoreID);
				result.Add(model);
			}

			return result;
		}

		private StoreServiceModel ManualMap(Store source)
		{
			StoreServiceModel result = new StoreServiceModel();
			result.StoreID = source.StoreID;
			result.StoreName = source.StoreName;
			result.StoreAdminAccountID = source.StoreAdminAccountID;
			result.StoreAdmin = source.StoreAdmin;
			result.Staffs = source.Staffs;
			result.Location= source.Location;
			result.Status = source.Status;
			result.products = new List<InStoreProduct>();

			return result;
		}

		private Store ManualMap(StoreServiceModel source)
		{
			Store result = new Store();
			result.StoreID = source.StoreID;
			result.StoreName = source.StoreName;
			result.StoreAdminAccountID = source.StoreAdminAccountID;
			result.StoreAdmin = source.StoreAdmin;
			result.Staffs = source.Staffs;
			result.Location = source.Location;
			result.Status = source.Status;

			return result;
		}
	}
}
