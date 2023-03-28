using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StorePageModel : PageModel
    {
		private readonly IInstoreProductService _instoreProductService;

		public Account Account { get; set; }
        public List<InStoreProduct> Products { get; set; }
        public StorePageModel(IInstoreProductService instoreProductService)
        {
			_instoreProductService = instoreProductService;
		}

        public async Task OnGetAsync(Guid? storeId)
        {

            Products = await GetProductsInStore((Guid)storeId);
        }

        private async Task<List<InStoreProduct>> GetProductsInStore(Guid storeId)
        {
            return await Task.FromResult(_instoreProductService.GetInStoreProducts(storeId));
        }
    }
}
