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
    public class IndexModel : PageModel
    {
        private readonly IStoreService _storeService;

        public IndexModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IList<StoreServiceModel> Store { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var stores = _storeService.GetAll();

            if (stores != null)
            {
                Store = stores;
            }
        }
    }
}
