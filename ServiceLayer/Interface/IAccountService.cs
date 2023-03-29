using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interface
{
	public interface IAccountService
	{
		Account Login(string username, string password);
		Account GetById(Guid id);

        List<Account> GetAll(Guid AdminStoreId);
        Account Get(Guid AccountId);
        IEnumerable<Account> GetAll();
        bool Edit(Account account);
        void Delete(Guid accountId);
        bool Create(Account account);
        Account getDetail(Guid accountId);
        List<Account> GetAvailableAdmins();

	}

}
