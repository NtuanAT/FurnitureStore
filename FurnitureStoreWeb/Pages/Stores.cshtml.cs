using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interface;
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.Pages
{
    public class StoresModel : PageModel
    {
        private readonly IStoreService _storeService;
        
        public StoresModel(IStoreService storeService)
        {
            _storeService = storeService;           
        }

        public List<StoreServiceModel> Stores { get; set; }

        public async Task OnGetAsync()
        {
            Stores = await GetStoresAsync(); // Replace with your method to retrieve stores
        }

        private async Task<List<StoreServiceModel>> GetStoresAsync()
        {
            return await Task.FromResult(_storeService.GetAll());
        }
    }
}
