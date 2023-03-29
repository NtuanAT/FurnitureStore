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
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages.Admin.StoreManagement
{
    public class CreateModel : PageModel
    {
        private readonly IStoreService _storeService;
        private readonly IAccountService _accountService;

        public CreateModel(IStoreService storeService,
            IAccountService accountService)
        {
            _storeService = storeService;
            _accountService = accountService;
        }

        public IActionResult OnGet()
        {

            var statuses = Enum.GetValues(typeof(StoreStatus))
               .Cast<StoreStatus>()
               .Select(e => new SelectListItem
               {
                   Value = e.ToString(),
                   Text = e.ToString()
               }).ToList();

            ViewData["AvailableAdmin"] = new SelectList(_accountService.GetAvailableAdmins(), "AccountID", "Username");
            ViewData["Status"] = new SelectList(statuses, "Value", "Text");

            return Page();
        }

        [BindProperty]
        public StoreServiceModel Store { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Store == null)
            {
                var statuses = Enum.GetValues(typeof(StoreStatus))
               .Cast<StoreStatus>()
               .Select(e => new SelectListItem
               {
                   Value = e.ToString(),
                   Text = e.ToString()
               }).ToList();

                ViewData["AvailableAdmin"] = new SelectList(_accountService.GetAvailableAdmins(), "AccountID", "Username");
                ViewData["Status"] = new SelectList(statuses, "Value", "Text");
                return Page();
            }

            _storeService.CreateStore(Store);

            return RedirectToPage("./Index");
        }
    }
}
