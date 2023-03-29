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
using ServiceLayer.ServiceModel;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages.Admin.WarehouseManagement
{
    public class EditModel : PageModel
    {
        private readonly IWareHouseService _wareHouseService;

        public EditModel(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [BindProperty]
        public WareHouseServiceModel Warehouse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var warehouses = _wareHouseService.GetAll();

            if (id == null || warehouses == null)
            {
                return NotFound();
            }

            var warehouse = warehouses.FirstOrDefault(m => m.WareHouseID == id);
            if (warehouse == null)
            {
                return NotFound();
            }
            else
            {
                Warehouse = warehouse;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrWhiteSpace(Warehouse.Name) ||
                String.IsNullOrWhiteSpace(Warehouse.Location))
            {
                return Page();
            }

            _wareHouseService.UpdateWarehouse(Warehouse);

            return RedirectToPage("./Index");
        }

    }
}
