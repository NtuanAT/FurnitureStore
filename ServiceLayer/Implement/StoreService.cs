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
        private readonly IAccountRepository _accountRepository;

        public StoreService(IStoreRepository storeRepository, IInStoreProductRepository inStoreProductRepository, IMapper mapper,
			IAccountRepository accountRepository)
        {
            _storeRepository = storeRepository;
            _products = inStoreProductRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public bool CloseStore(Guid storeId)
        {
            return _storeRepository.CloseStore(storeId);
        }

        public List<StoreServiceModel> GetAll()
		{
			
			var entites = _storeRepository.GetAllWithRelated();

			var result = new List<StoreServiceModel>();
			foreach (var item in entites)
			{
				StoreServiceModel model = ManualMap(item);
				model.products = _products.GetAllProductInPlace(model.StoreID);
				result.Add(model);
			}

			return result;
		}

        public bool UpdateStore(StoreServiceModel store, Guid newAdminAccount)
        {
			var updateStore = ManualMap(store);

            if (store == null) return false;

			var oldAdmin = _accountRepository.GetAdminAccountByStoreId(store.StoreID);
			if (oldAdmin != null)
			{
				_accountRepository.RemoveAdminFromStore(store.StoreID);
			}

            updateStore.StoreAdminAccountID = newAdminAccount;
			var newAdmin = _accountRepository.Get(a => a.AccountID.Equals(newAdminAccount));
			newAdmin.AdminStoreID = store.StoreID;

			return _accountRepository.Update(newAdmin) && _storeRepository.Update(updateStore);
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

        public bool CreateStore(StoreServiceModel store)
        {
			var createStore = ManualMap(store);
			bool check = _storeRepository.Create(createStore);

			if (check)
			{
				return _accountRepository.AssignAdminToStore(createStore.StoreID, store.StoreAdminAccountID);

            }


            return false; // can't asign admin
        }
    }
}
