using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Interface;
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Management
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _context;
        private readonly IStoreService _storeService;


        public CreateModel(IAccountService context, IStoreService storeService)
        {
            _context = context;
            _storeService = storeService;
        }

        public IActionResult OnGet()
        {

            var user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("LogginUser"));
            if(user.Role == 0)
            {
                ViewData["StaffStoreID"] = new SelectList(_storeService.GetAll(), "StoreID", "Location");
                return Page();
            }
            return Unauthorized();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (_context.GetAll() == null || Account == null)
            {

                return Page();
            }

            _context.Create(Account);

            return RedirectToPage("./Index");
        }
    }
}
