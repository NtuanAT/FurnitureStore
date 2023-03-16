using DataLayer.Entities;
using DataLayer.Repository.Interface;
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

		public Account Login(string username, string password)
		{
			return _dbSet.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
		}
	}
}
