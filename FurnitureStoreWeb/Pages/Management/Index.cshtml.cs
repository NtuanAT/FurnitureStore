using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using Newtonsoft.Json;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages.Management
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;

        public IndexModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IList<Account> Account { get; set; }

        public async Task OnGetAsync()
        {

            Account = await GetAccountsAsync();
        }
        private async Task<List<Account>> GetAccountsAsync()
        {
            Account? user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("LogginUser")!);
            return await Task.FromResult(_accountService.GetAll(user.AdminStoreID.Value));
        }
    }
}
