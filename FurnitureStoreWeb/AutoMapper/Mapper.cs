using AutoMapper;
using DataLayer.Entities;
using ServiceLayer.ServiceModel;

namespace FurnitureStoreWeb.AutoMapper
{
	public class Mapper : Profile
	{
		public Mapper()
		{
			CreateMap<Store, StoreServiceModel>()
				.ConstructUsing(src => new StoreServiceModel { products = new List<InStoreProduct>() })
				.ReverseMap();

			CreateMap<Warehouse, WareHouseServiceModel>()
				.ConstructUsing(src => new WareHouseServiceModel { products = new List<InStoreProduct>() })
				.ReverseMap();
		}
	}
}
