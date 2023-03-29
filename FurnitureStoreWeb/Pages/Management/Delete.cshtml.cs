using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Repository.Interface;
using ServiceLayer.Interface;
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Management
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountService _context;

        public DeleteModel(IAccountService context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public ActionResult OnGet(Guid? id)
        {
            var user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("LoginAccount"));
            if (user.Role == 0) 
            {
                if (id == null || _context.Get(id.Value) == null)
                {
                    return NotFound();
                }

                var account = _context.Get(id.Value);

                if (account == null)
                {
                    return NotFound();
                }
                else
                {
                    Account = account;
                }
                return Page();
            }
            return Unauthorized();
        }

        public IActionResult OnPost(Guid? id)
        {
            if (id == null || _context.Get(id.Value) == null)
            {
                return NotFound();
            }
            var account = _context.Get(id.Value);

            if (account != null)
            {
                Account = account;
                _context.Delete(account.AccountID);

            }

            return RedirectToPage("./Index");
        }
    }
}
