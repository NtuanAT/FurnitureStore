using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.Interface;
using System.Text.Json;

namespace FurnitureStoreWeb.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IAccountService _accountService;

		[BindProperty]
		public Account account { get; set; }

		public IndexModel(IAccountService accountService)
		{
			_accountService = accountService;
			//Fix loi null object reference
			account = new Account();
		}

		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{

            var result = _accountService.Login(account.Username, account.Password);

            if (result != null)
            {
                HttpContext.Session.SetString("LogginUser", JsonConvert.SerializeObject(result));
                if (result.Role == AccountRole.Admin)
                {
                    return RedirectToPage("Admin/AdminHomePage");
                }
                else if (result.Role == AccountRole.Staff)
                {
                    return RedirectToPage("StaffHomePage");
                }
                return RedirectToPage("Stores");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }

	}
}