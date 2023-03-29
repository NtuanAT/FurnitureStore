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

namespace FurnitureStoreWeb.Pages.Admin.StoreManagement
{
    public class DetailsModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DetailsModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

      public StoreServiceModel Store { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            var stores = _storeService.GetAll();

            if (id == null || stores == null)
            {
                return NotFound();
            }

            var store = stores.FirstOrDefault(m => m.StoreID == id);
            if (store == null)
            {
                return NotFound();
            }
            else 
            {
                Store = store;
            }
            return Page();
        }
    }
}
