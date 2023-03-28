using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
		}

		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{
			var result = _accountService.Login(account.Username, account.Password);
			if (result != null)
			{

                if (result.Role == AccountRole.Admin)
                {
                    var serializedObject = JsonSerializer.Serialize(result);

                    // Set session object
                    HttpContext.Session.SetString("AdminAccount", serializedObject);



                    return RedirectToPage("Admin/ProductManagement/Index");
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