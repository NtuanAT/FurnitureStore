using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class InStoreProductListModel : PageModel
    {
        IInstoreProductService _productService;

        [BindProperty]
        public List<InStoreProduct> products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

        private readonly int PAGESIZE = 3;


        public InStoreProductListModel(IInstoreProductService instoreProductService)
        {
            _productService = instoreProductService;
            products = new List<InStoreProduct>();
            CountTotalPage(_productService.Count());
		}


        public IActionResult OnGet(int pageIndex = 1)
        {
            CurrentPage = pageIndex;
            products = _productService.GetInStoreProductWithIncludeAndPaging(PAGESIZE, pageIndex);
            return Page();
        }

        public IActionResult OnPostPaginate(int pageIndex)
        {
            return OnGet(pageIndex);
        }

        private void CountTotalPage(int dbSetCount)
        {
            if(dbSetCount % PAGESIZE == 0)
            {
                TotalPage = dbSetCount / PAGESIZE;
            }
            else
            {
                TotalPage = dbSetCount / PAGESIZE + 1;
            }
        }
    }
}
