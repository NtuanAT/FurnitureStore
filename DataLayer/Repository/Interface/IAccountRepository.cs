using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
	public interface IAccountRepository : IRepositoryBase<Account>
	{
		Account Login(string username, string password);
        Account GetDetails(Guid id);
    }

}
