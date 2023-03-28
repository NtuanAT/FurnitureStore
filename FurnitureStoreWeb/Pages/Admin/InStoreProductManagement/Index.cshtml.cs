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
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FurnitureStoreWeb.Pages.Admin.InStoreProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public IndexModel(IInStoreProductService inStoreProductService,
            IProductService productService,
            IStoreService storeService)
        {
            _inStoreProductService = inStoreProductService;
            _productService = productService;
            _storeService = storeService;
        }

        public IList<InStoreProduct> InStoreProduct { get;set; } = default!;
        private Account adminAccount;
        [BindProperty]
        public InStoreProduct searchInStoreProduct { get; set; }
        [BindProperty]
        public string storeName { get; set; }

        public async Task OnGet()
        {
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);
            ViewData["ProductName"] = new SelectList(_productService.GetAllByStoreId((Guid)adminAccount.AdminStoreID), "ProductName", "ProductName");
            storeName = _storeService.GetAll().Where(s => s.StoreID.Equals(adminAccount.AdminStoreID)).FirstOrDefault().StoreName;

            InStoreProduct = _inStoreProductService.GetAllProductsInStore((Guid)adminAccount.AdminStoreID);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrWhiteSpace(searchInStoreProduct.Product.ProductName))
            {
                return NotFound();
            }
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);
            ViewData["ProductName"] = new SelectList(_productService.GetAllByStoreId((Guid)adminAccount.AdminStoreID), "ProductName", "ProductName");
            storeName = _storeService.GetAll().Where(s => s.StoreID.Equals(adminAccount.AdminStoreID)).FirstOrDefault().StoreName;

            InStoreProduct = _inStoreProductService.GetAllProductsInStore((Guid)adminAccount.AdminStoreID);
            InStoreProduct = InStoreProduct.Where(i => i.Product.ProductName.Contains(searchInStoreProduct.Product.ProductName)).ToList();
            
            return Page();
        }
    }
}
