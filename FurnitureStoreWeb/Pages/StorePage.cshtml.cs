using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StorePageModel : PageModel
    {
		private readonly IInStoreProductService _instoreProductService;
		public Account Customer { get; set; }
        public List<InStoreProduct> Products { get; set; }
        public StorePageModel(IInStoreProductService instoreProductService)
        {
			_instoreProductService = instoreProductService;
		}

        public async Task OnGetAsync(Guid? storeId)
        {

            Products = await GetProductsInStore((Guid)storeId);
			var customer = HttpContext.Session.GetString("CustomerAccount");
			Customer = JsonConvert.DeserializeObject<Account>(customer);
		}

        

		private async Task<List<InStoreProduct>> GetProductsInStore(Guid storeId)
        {
            return await Task.FromResult(_instoreProductService.GetAllProductsInStore(storeId));
        }
    }
}
