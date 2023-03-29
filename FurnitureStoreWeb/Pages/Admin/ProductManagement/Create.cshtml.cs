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

namespace FurnitureStoreWeb.Pages.Admin.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (String.IsNullOrWhiteSpace(Product.ProductName) ||
                String.IsNullOrWhiteSpace(Product.Category) ||
                Product.Price < 0)
            {
                return Page();
            }

            _productService.CreateProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}
