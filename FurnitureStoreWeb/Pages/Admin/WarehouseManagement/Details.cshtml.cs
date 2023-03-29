using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using ServiceLayer.ServiceModel;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages.Admin.WarehouseManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IWareHouseService _wareHouseService;

        public DetailsModel(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

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
    }
}
