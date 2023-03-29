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
    public class DetailsModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;

        public DetailsModel(IInStoreProductService inStoreProductService)
        {
            _inStoreProductService = inStoreProductService;
        }

        public InStoreProduct InStoreProduct { get; set; } = default!;
        private Account adminAccount;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            // Retrieve session object 
            string serializedObject = HttpContext.Session.GetString("LoginAccount");
            adminAccount = JsonSerializer.Deserialize<Account>(serializedObject);

            if (id == null)
            {
                return NotFound();
            }

            var instoreproduct = _inStoreProductService.GetProductInPlace((Guid)id);
            if (instoreproduct == null)
            {
                return NotFound();
            }
            else
            {
                InStoreProduct = instoreproduct;
            }
            return Page();
        }
    }
}
