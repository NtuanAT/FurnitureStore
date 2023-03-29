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
using ServiceLayer.ServiceModel;
using static System.Formats.Asn1.AsnWriter;

namespace FurnitureStoreWeb.Pages.Admin.StoreManagement
{
    public class EditModel : PageModel
    {
        private readonly IStoreService _storeService;
        private readonly IAccountService _accountService;

        public EditModel(IStoreService storeService,
            IAccountService accountService)
        {
            _storeService = storeService;
            _accountService = accountService;
        }

        [BindProperty]
        public StoreServiceModel Store { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var stores = _storeService.GetAll();

            if (id == null || stores == null)
            {
                return NotFound();
            }

            var store =  stores.FirstOrDefault(m => m.StoreID == id);
            if (store == null)
            {
                return NotFound();
            }
            Store = store;

            var statuses = Enum.GetValues(typeof(StoreStatus))
                   .Cast<StoreStatus>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   }).ToList();

            var SelectableAdmins = _accountService.GetAvailableAdmins();
            SelectableAdmins.Add(new Account { AccountID = store.StoreAdminAccountID, Username = store.StoreAdmin.Username });

            ViewData["AvailableAdmin"] = new SelectList(SelectableAdmins, "AccountID", "Username", store.StoreAdminAccountID);
            ViewData["Status"] = new SelectList(statuses, "Value", "Text", store.Status);


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Store == null)
            {
                var stores = _storeService.GetAll();
                var store = stores.FirstOrDefault(m => m.StoreID == Store.StoreID);

                var statuses = Enum.GetValues(typeof(StoreStatus))
                   .Cast<StoreStatus>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   }).ToList();

                var SelectableAdmins = _accountService.GetAvailableAdmins();
                SelectableAdmins.Add(new Account { AccountID = store.StoreAdminAccountID, Username = store.StoreAdmin.Username });

                ViewData["AvailableAdmin"] = new SelectList(SelectableAdmins, "AccountID", "Username", store.StoreAdminAccountID);
                ViewData["Status"] = new SelectList(statuses, "Value", "Text", store.Status);

                return Page();
            }

            _storeService.UpdateStore(Store, Store.StoreAdminAccountID);

            return RedirectToPage("./Index");
        }

    }
}
