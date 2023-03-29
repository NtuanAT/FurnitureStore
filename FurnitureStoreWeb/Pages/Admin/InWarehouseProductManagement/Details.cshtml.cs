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
using ServiceLayer.Implement;

namespace FurnitureStoreWeb.Pages.Admin.InWarehouseProductManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IWareHouseService _wareHouseService;

        public DetailsModel(IInStoreProductService inStoreProductService, IWareHouseService wareHouseService)
        {
            _inStoreProductService = inStoreProductService;
            _wareHouseService = wareHouseService;
        }

        public InStoreProduct InStoreProduct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
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
                var warehouses = _wareHouseService.GetAll();
                // map warehouse IDs to names
                var warehouseNames = warehouses.ToDictionary(w => w.WareHouseID, w => w.Name);
                // set ViewBag property
                ViewData["WarehouseName"] = warehouseNames;

                InStoreProduct = instoreproduct;
            }
            return Page();
        }
    }
}
