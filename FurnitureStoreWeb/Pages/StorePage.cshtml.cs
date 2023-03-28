using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StorePageModel : PageModel
    {
        private readonly IStoreService _storeService;

        public Account Account { get; set; }
        public List<InStoreProduct> Products { get; set; }
        public StorePageModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public async Task OnGetAsync(Guid? storeId)
        {

        }
    }
}
