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
		List<Account> GetAvailableAdmins();
	}
}
