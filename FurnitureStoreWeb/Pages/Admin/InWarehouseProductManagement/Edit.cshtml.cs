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

namespace FurnitureStoreWeb.Pages.Admin.InWarehouseProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IStoreService _storeService;
        private readonly IWareHouseService _wareHouseService;

        public EditModel(IInStoreProductService inStoreProductService,
            IStoreService storeService,
            IWareHouseService wareHouseService)
        {
            _inStoreProductService = inStoreProductService;
            _storeService = storeService;
            _wareHouseService = wareHouseService;
        }

        [BindProperty]
        public InStoreProduct InStoreProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
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

            var instoreproduct = _inStoreProductService.GetProductInPlace((Guid)id);
            if (instoreproduct == null)
            {
                return NotFound();
            }

            InStoreProduct = instoreproduct;
            ViewData["WarehouseID"] = new SelectList(_wareHouseService.GetAll(), "WareHouseID", "Name");
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
