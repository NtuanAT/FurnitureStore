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

namespace FurnitureStoreWeb.Pages.Admin.InStoreProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;

        public IndexModel(IInStoreProductService inStoreProductService)
        {
            _inStoreProductService = inStoreProductService;
        }

        public IList<InStoreProduct> InStoreProduct { get;set; } = default!;
        private Account adminAccount;

        public async Task OnGet()
        {
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("AdminAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            InStoreProduct = _inStoreProductService.GetAllProductsInStore((Guid)adminAccount.AdminStoreID);
        }
    }
}
