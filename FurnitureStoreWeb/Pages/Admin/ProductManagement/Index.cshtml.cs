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

namespace FurnitureStoreWeb.Pages.Admin.ProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> Product { get;set; } = default!;
        private Account adminAccount;
        [BindProperty]
        public Product searchProduct { get; set; }

        public async Task OnGetAsync()
        {

            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            if (adminAccount.AdminStoreID != null)
            {
                Product = _productService.GetAllByStoreId((Guid)adminAccount.AdminStoreID);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrWhiteSpace(searchProduct.ProductName))
            {
                return NotFound();
            }
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            Product = _productService.GetAllByStoreId((Guid)adminAccount.AdminStoreID);
            Product = Product.Where(i => i.ProductName.Contains(searchProduct.ProductName)).ToList();

            return Page();
        }
    }
}
