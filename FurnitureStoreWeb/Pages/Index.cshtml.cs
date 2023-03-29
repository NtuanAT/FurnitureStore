using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.Interface;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FurnitureStoreWeb.Pages
{
	public class IndexModel : PageModel
	{
		private readonly IAccountService _accountService;

		[BindProperty]
		public Account Account { get; set; }

		public IndexModel(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public void OnGet()
		{
			Account = new Account();
		}

		public IActionResult OnPost()
		{
			var result = _accountService.Login(Account.Username, Account.Password);
			if (result != null)
			{

                var serializedObject = JsonSerializer.Serialize(result);
				// Set session object
				HttpContext.Session.SetString("LoginAccount", serializedObject);
				if (result.Role == AccountRole.Admin)
                {                    
                    return RedirectToPage("Admin/AdminHomePage");
                }
                if (result.Role == AccountRole.Staff)
                {
                    return RedirectToPage("StaffHomePage");
                }
				if(result.Role == AccountRole.Customer)				{
					
					return RedirectToPage("Stores");
				}
				return RedirectToPage("Error");
			}
			else
			{
				return RedirectToPage("Error");
			}
		}
	}
}