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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FurnitureStoreWeb.Pages.Admin.InWarehouseProductManagement
{
    public class IndexModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly IWareHouseService _wareHouseService;

        public IndexModel(IInStoreProductService inStoreProductService,
            IProductService productService,
            IStoreService storeService,
            IWareHouseService wareHouseService)
        {
            _inStoreProductService = inStoreProductService;
            _productService = productService;
            _storeService = storeService;
            _wareHouseService = wareHouseService;
        }

        public IList<InStoreProduct> InStoreProduct { get;set; } = default!;
        [BindProperty]
        public InStoreProduct searchInStoreProduct { get; set; }



        public async Task OnGet()
        {
            var warehouses = _wareHouseService.GetAll();
            // map warehouse IDs to names
            var warehouseNames = warehouses.ToDictionary(w => w.WareHouseID, w => w.Name);
            // set ViewBag property
            ViewData["WarehouseName"] = warehouseNames;

            ViewData["ProductName"] = new SelectList(_productService.GetAll(), "ProductName", "ProductName");

            InStoreProduct = _inStoreProductService.GetAllInWarehouseProducts();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrWhiteSpace(searchInStoreProduct.Product.ProductName))
            {
                return NotFound();
            }

            var warehouses = _wareHouseService.GetAll();
            // map warehouse IDs to names
            var warehouseNames = warehouses.ToDictionary(w => w.WareHouseID, w => w.Name);
            // set ViewBag property
            ViewData["WarehouseName"] = warehouseNames;

            ViewData["ProductName"] = new SelectList(_productService.GetAll(), "ProductName", "ProductName");

            InStoreProduct = _inStoreProductService.GetAllInWarehouseProducts();
            InStoreProduct = InStoreProduct.Where(i => i.Product.ProductName.Contains(searchInStoreProduct.Product.ProductName)).ToList();
            
            return Page();
        }
    }
}
