using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StorePageModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
        public StorePageModel(IInStoreProductService inStoreProductService)
        {
			_inStoreProductService = inStoreProductService;
        }
        public List<InStoreProduct> Products { get; set; }
        public async Task OnGetAsync(Guid storeId)
        {
            Products = await GetInStoreProducts(storeId);
        }

        async Task<List<InStoreProduct>> GetInStoreProducts(Guid storeId)
        {
            return await Task.FromResult(_inStoreProductService.GetAllProductsInStore(storeId));
        }

	}
}
