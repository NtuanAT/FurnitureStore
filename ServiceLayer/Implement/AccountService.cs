using DataLayer.Entities;
using DataLayer.Repository.Interface;
using ServiceLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implement
{
	public class AccountService : IAccountService
	{
		IAccountRepository _accountRepository;
		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public Account GetById(Guid id)
		{
			return _accountRepository.Get(a => a.AccountID == id);
		}

		public Account Login(string username, string password)
		{
			return _accountRepository.Login(username, password);
		}
        public Account getDetail(Guid accountId) => _accountRepository.GetDetails(accountId);

        public bool Create(Account account) => _accountRepository.Create(account);

        public void Delete(Guid accountId) => _accountRepository.Delete(a => a.AccountID == accountId);


        public bool Edit(Account account) => _accountRepository.Update(account);


        public Account Get(Guid AccountId) => _accountRepository.Get(a => a.AccountID == AccountId);


        public List<Account> GetAll(Guid AdminStoreId)
        {

            return _accountRepository.GetAll().Where(a => a.StaffStoreID == AdminStoreId).ToList();
        }

        public IEnumerable<Account> GetAll() => _accountRepository.GetAll();
    }
}
