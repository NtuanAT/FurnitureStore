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
    }
}
