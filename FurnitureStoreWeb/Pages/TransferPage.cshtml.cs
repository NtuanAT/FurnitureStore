using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.Interface;
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages
{
    public class TransferPageModel : PageModel
    {
        private IWareHouseService _warehouses;
        private IStoreService _stores;
        private IProductService _products;
        private IInStoreProductService _instoreService;
        public TransferPageModel(IStoreService storeService, IWareHouseService wareHouseService, IProductService productService, IInStoreProductService instoreProductService)
        {
            _stores = storeService;
            _warehouses = wareHouseService;
            _products = productService;
            _instoreService = instoreProductService;
        }
        public void OnGet()
        {
        }

        public IActionResult OnGetDocumentReady()
        {
            var status = true;
            var errorMessage = string.Empty;

            var stores = new List<StoreServiceModel>();
			var warehouses = new List<WareHouseServiceModel>();
            var products = new List<Product>();

			try
            {
				stores = _stores.GetAll();
				warehouses = _warehouses.GetAll();

                foreach(var store in stores)
                {
                    foreach(var instore in store.products)
                    {
                        products.Add(instore.Product);
                    }
                }
				foreach (var warehouse in warehouses)
				{
					foreach (var instore in warehouse.products)
					{
						products.Add(instore.Product);
					}
				}

                products = products.GroupBy(product => product.ProductID).Select(group => group.First()).ToList();
			}
			catch(Exception ex)
            {
                status = false;
                errorMessage= ex.Message;
            }

            var data = new
            {
                stores = stores,
                warehouses = warehouses,
                products = products
            };

            var lists = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });


			return new JsonResult(new {
                status = status,
                errorMessage = errorMessage,
                lists = lists
            });
        }

        public IActionResult OnGetTransfer(string warehouseProductID, string storeProductID, int quantity)
        {
            var status = true;
            var errorMessage = string.Empty;

            try
            {
                _instoreService.Transfer(Guid.Parse(warehouseProductID), Guid.Parse(storeProductID), quantity);

			}
			catch(Exception ex)
            {
                status = false;
                errorMessage = ex.Message;
            }

            return new JsonResult(new
            {
                status = status,
                errorMessage = errorMessage
            });
        }
    }
}
