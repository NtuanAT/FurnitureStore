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
using System.Text.Json;

namespace FurnitureStoreWeb.Pages.Admin.InStoreProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IStoreService _storeService;

        public EditModel(IInStoreProductService inStoreProductService,
            IStoreService storeService)
        {
            _inStoreProductService = inStoreProductService;
            _storeService = storeService;
        }

        [BindProperty]
        public InStoreProduct InStoreProduct { get; set; } = default!;
        private Account adminAccount;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            var statuses = Enum.GetValues(typeof(ProductStatus))
                   .Cast<ProductStatus>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   }).ToList();


            if (id == null)
            {
                return NotFound();
            }

            var instoreproduct = _inStoreProductService.GetProductInStore((Guid)id);
            if (instoreproduct == null)
            {
                return NotFound();
            }
            InStoreProduct = instoreproduct;
            ViewData["StoreID"] = new SelectList(_storeService.GetAll(), "StoreID", "StoreName");
            ViewData["Status"] = new SelectList(statuses, "Value", "Text", InStoreProduct.Status);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (InStoreProduct.Quantity < 0 )
            {
                return Page();
            }


            _inStoreProductService.UpdateTrackedInStoreProduct(InStoreProduct);


            return RedirectToPage("./Index");
        }


    }
}
