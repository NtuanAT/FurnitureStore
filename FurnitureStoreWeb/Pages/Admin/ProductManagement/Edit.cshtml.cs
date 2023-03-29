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

namespace FurnitureStoreWeb.Pages.Admin.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
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
            Product = product;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrWhiteSpace(Product.ProductName) ||
                String.IsNullOrWhiteSpace(Product.Category) ||
                Product.Price < 0)
            {
                return Page();
            }

            _productService.UpdateTrackedProduct(Product);

            return RedirectToPage("./Index");
        }

    }
}
