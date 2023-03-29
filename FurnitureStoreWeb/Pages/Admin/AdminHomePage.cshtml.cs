using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Admin
{
    public class AdminHomePageModel : PageModel
    {
        public Account AdminAccount { get; set; }
        public void OnGet()
        {
            var admin = HttpContext.Session.GetString("LoginAccount");
			AdminAccount = JsonConvert.DeserializeObject<Account>(admin);
        }
    }
}
