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
		public Account Login(string username, string password)
		{
			return _accountRepository.Login(username, password);
		}
	}
}
