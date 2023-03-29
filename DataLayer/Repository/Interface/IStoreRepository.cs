using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public interface IStoreRepository : IRepositoryBase<Store>
	{
		List<Store> GetAllWithRelated();
		bool CloseStore(Guid storeId);
	}
}
