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
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages.Admin.WarehouseManagement
{
    public class CreateModel : PageModel
    {
        private readonly IWareHouseService _wareHouseService;

        public CreateModel(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WareHouseServiceModel Warehouse { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (String.IsNullOrWhiteSpace(Warehouse.Name) ||
                String.IsNullOrWhiteSpace(Warehouse.Location) || Warehouse == null)
            {
                return Page();
            }

            _wareHouseService.AddWarehouse(Warehouse);

            return RedirectToPage("./Index");
        }
    }
}
