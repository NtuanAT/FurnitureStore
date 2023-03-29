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

namespace FurnitureStoreWeb.Pages.Admin.InWarehouseProductManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;

        public DeleteModel(IInStoreProductService inStoreProductService)
        {
            _inStoreProductService = inStoreProductService;
        }

        [BindProperty]
        public InStoreProduct InStoreProduct { get; set; } = default!;

        public IActionResult OnGet(Guid? id)
        {
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

        public IActionResult OnPost(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instoreproduct = _inStoreProductService.GetProductInPlace((Guid)id);

            if (instoreproduct != null)
            {
                InStoreProduct = instoreproduct;
                _inStoreProductService.DeActivateProductInStore(instoreproduct);
            }

            return RedirectToPage("./Index");
        }
    }
}
