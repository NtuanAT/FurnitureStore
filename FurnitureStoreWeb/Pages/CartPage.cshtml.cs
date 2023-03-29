using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FurnitureStoreWeb.Pages
{
    public class CartPageModel : PageModel
    {

        public Account CustomerAccount { get; set; }
        
        public IActionResult OnGet()
        {
			if (HttpContext.Session.TryGetValue("LoginAccount", out byte[] value))
            {
				CustomerAccount = System.Text.Json.JsonSerializer.Deserialize<Account>(value);
			}
			else
            {
				return RedirectToPage("/Index");
			}
			return Page();
		}

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
