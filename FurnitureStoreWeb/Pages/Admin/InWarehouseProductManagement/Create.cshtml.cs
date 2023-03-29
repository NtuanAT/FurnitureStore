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
using System.Text.Json;

namespace FurnitureStoreWeb.Pages.Admin.InWarehouseProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;
        private readonly IWareHouseService _wareHouseService;

        public CreateModel(IInStoreProductService inStoreProductService,
            IStoreService storeService,
            IProductService productService,
            IWareHouseService wareHouseService)
        {
            _inStoreProductService = inStoreProductService;
            _storeService = storeService;
            _productService = productService;
            _wareHouseService = wareHouseService;
        }


        public IActionResult OnGet()
        {

            var statuses = Enum.GetValues(typeof(ProductStatus))
                   .Cast<ProductStatus>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   }).ToList();


            ViewData["ProductID"] = new SelectList(_productService.GetAll(), "ProductID", "ProductName");
            ViewData["WarehouseID"] = new SelectList(_wareHouseService.GetAll(), "WareHouseID", "Name");
            ViewData["Status"] = new SelectList(statuses, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public InStoreProduct InStoreProduct { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (InStoreProduct.Quantity < 0 || InStoreProduct == null)
            {
                return Page();
            }

            _inStoreProductService.CreateInStoreProduct(InStoreProduct);

            return RedirectToPage("./Index");
        }
    }
}
