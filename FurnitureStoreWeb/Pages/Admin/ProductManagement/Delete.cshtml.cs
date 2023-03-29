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
using Newtonsoft.Json;

namespace FurnitureStoreWeb.Pages.Admin.ProductManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
      public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("AdminAccount"));  
            if (user.Role == 0)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var product = _productService.GetProductById((Guid)id);

                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    Product = product;
                }
                return Page();
            }
            return Unauthorized();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetProductById((Guid)id);

            if (product != null)
            {
                _productService.DeleteProduct(product.ProductID);
            }

            return RedirectToPage("./Index");
        }
    }
}
