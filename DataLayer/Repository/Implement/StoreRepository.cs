using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class StoreRepository : RepositoryBase<Store>, IStoreRepository
	{
		public StoreRepository(StoreDBContext context) : base(context)
		{
		}

        public bool CloseStore(Guid storeId)
        {
            var updateStore = _dbSet.Find(storeId);
            if (updateStore != null)
            {
                updateStore.Status = StoreStatus.Close;
                return Update(updateStore);
            }
            else
            {
                return false;
            }
        }

        public List<Store> GetAllWithRelated()
        {
            return _dbSet.Include(x => x.StoreAdmin).ToList();
        }
    }
}
