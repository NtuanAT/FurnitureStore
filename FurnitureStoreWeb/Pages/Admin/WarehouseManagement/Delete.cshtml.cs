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
using ServiceLayer.Implement;
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages.Admin.WarehouseManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IWareHouseService _wareHouseService;

        public DeleteModel(IWareHouseService wareHouseService)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            _wareHouseService.DeleteWarehouse((Guid)id);

            return RedirectToPage("./Index");
        }
    }
}
