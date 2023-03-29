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

namespace FurnitureStoreWeb.Pages.Admin.InStoreProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;

        public CreateModel(IInStoreProductService inStoreProductService,
            IStoreService storeService,
            IProductService productService)
        {
            _inStoreProductService = inStoreProductService;
            _storeService = storeService;
            _productService = productService;
        }

        private Account adminAccount;

        public IActionResult OnGet()
        {
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("LoginAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            var statuses = Enum.GetValues(typeof(ProductStatus))
                   .Cast<ProductStatus>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   }).ToList();


            ViewData["ProductID"] = new SelectList(_productService.GetAllByStoreId((Guid)adminAccount.AdminStoreID), "ProductID", "ProductName");
            ViewData["StoreID"] = new SelectList(_storeService.GetAll(), "StoreID", "StoreName");
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

            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("LoginAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            _inStoreProductService.CreateInStoreProduct(InStoreProduct);

            return RedirectToPage("./Index");
        }
    }
}
