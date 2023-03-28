using AutoMapper;
using DataLayer;
using DataLayer.Repository.Implement;
using DataLayer.Repository.Interface;
using ServiceLayer.Implement;
using ServiceLayer.Interface;

namespace FurnitureStoreWeb
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddSession();
			builder.Services.AddDbContext<StoreDBContext>();
			builder.Services.AddAutoMapper(typeof(Mapper));

			builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

			builder.Services.AddScoped<IInStoreProductRepository, InStoreProductRepository>();
			builder.Services.AddScoped<IInStoreProductService, InstoreProductService>();

			builder.Services.AddScoped<IWareHouseRepository, WareHouseRepository>();
			builder.Services.AddScoped<IWareHouseService, WareHouseService>();

			builder.Services.AddScoped<IAccountRepository, AccountRepository>();
			builder.Services.AddScoped<IAccountService, AccountService>();

			builder.Services.AddScoped<IStoreRepository, StoreRepository>();
			builder.Services.AddScoped<IStoreService, StoreService>();

			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<IProductService, ProductService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}