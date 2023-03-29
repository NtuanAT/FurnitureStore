using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.Interface;
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Management
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _context;
        private readonly IStoreService _storeService;

        public EditModel(IAccountService context, IStoreService storeService)
        {
            _context = context;
            _storeService = storeService;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public IActionResult OnGet(Guid? id)
        {
            var user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("LogginUser"));
            if(user.Role == 0)
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
                Account = account;

                ViewData["StaffStoreID"] = new SelectList(_storeService.GetAll(), "StoreID", "Location");
                return Page();
            }
            return Unauthorized();
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Edit(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();

            }
            return RedirectToPage("./Index");
        }

    }
}
