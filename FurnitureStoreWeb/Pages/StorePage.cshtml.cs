using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StorePageModel : PageModel
    {
        private readonly IInStoreProductService _inStoreProductService;
		private readonly IAccountService _accountService;

		public StorePageModel(IInStoreProductService inStoreProductService,
            IAccountService accountService)
        {
			_inStoreProductService = inStoreProductService;
			_accountService = accountService;
		}
        public List<InStoreProduct> Products { get; set; }
        public Account Account { get; set; }
        public async Task OnGetAsync(Guid storeId, Guid accountId)
        {
            Products = await GetInStoreProducts(storeId);
            Account = _accountService.GetById(accountId);
        }

        async Task<List<InStoreProduct>> GetInStoreProducts(Guid storeId)
        {
            return await Task.FromResult(_inStoreProductService.GetAllProductsInStore(storeId));
        }

	}
}
