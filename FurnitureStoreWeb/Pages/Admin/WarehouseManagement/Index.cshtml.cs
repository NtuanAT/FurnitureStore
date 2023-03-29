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
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages.Admin.WarehouseManagement
{
    public class IndexModel : PageModel
    {
        private readonly IWareHouseService _wareHouseService;

        public IndexModel(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        public IList<WareHouseServiceModel> Warehouse { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var warehouse = _wareHouseService.GetAll();

            if (warehouse != null)
            {
                Warehouse = warehouse;
            }
        }
    }
}
