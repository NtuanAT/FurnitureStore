using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Interface;
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Management
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _context;

        public DetailsModel(IAccountService context)
        {
            _context = context;
        }

        public Account Account { get; set; } = default!;

        public IActionResult OnGet(Guid? id)
        {
            var user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("LogginUser"));
            if(user.Role == 0)
            {
                if (id == null || _context.getDetail(id.Value) == null)
                {
                    return NotFound();
                }

                var account = _context.getDetail(id.Value);
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
    }
}
