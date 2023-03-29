using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implement
{
	public class AccountRepository : RepositoryBase<Account>, IAccountRepository
	{
		public AccountRepository(StoreDBContext context) : base(context)
		{

		}

        public bool AssignAdminToStore(Guid storeId, Guid adminId)
        {
            var updateRecord = _dbSet.FirstOrDefault(x => x.AccountID.Equals(adminId));
            updateRecord.AdminStoreID = storeId;

            return Update(updateRecord);
        }

        public Account GetAdminAccountByStoreId(Guid storeId)
        {
            return _dbSet.FirstOrDefault(x => x.AdminStoreID.Equals(storeId));
        }

        public Account Login(string username, string password)
		{
			return _dbSet.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
		} 
        public Account GetDetails(Guid id)
        {
            return _dbSet.Include(a => a.AdminStore).Include(a => a.StaffStore).FirstOrDefault(a => a.AccountID == id);
            
            
           }

        public bool RemoveAdminFromStore(Guid storeId)
        {
            var updateRecord = _dbSet.FirstOrDefault(x => x.AdminStoreID.Equals(storeId));
            updateRecord.AdminStoreID = null;

            return Update(updateRecord);
        }
    }
}
