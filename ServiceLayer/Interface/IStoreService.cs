using DataLayer.Entities;
using ServiceLayer.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
    public interface IStoreService
    {
        List<StoreServiceModel> GetAll();
        bool CloseStore(Guid storeId);
        bool UpdateStore(StoreServiceModel store, Guid newAdminAccount);
        bool CreateStore(StoreServiceModel store);
    }
}
