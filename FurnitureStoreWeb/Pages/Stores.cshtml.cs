using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb.Pages
{
    public class StoresModel : PageModel
    {
        private readonly IStoreService _storeService;
        public StoresModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public List<Store> Stores { get; set; }

        //public async Task OnGetAsync()
        //{
        //    Stores = await GetStoresAsync(); // Replace with your method to retrieve stores
        //}

        //private async Task<List<Store>> GetStoresAsync()
        //{
        //    // Replace this with your actual method to retrieve stores from a database or another source.
        //    // This is a placeholder example that returns a static list of stores.
        //    return await Task.FromResult(_storeService.GetAll());
        //}
    }
}
