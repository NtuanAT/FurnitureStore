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
    public class AccountRepository : RepositoryBase<Account>,IAccountRepository<Account>
	{
	
	}
}
