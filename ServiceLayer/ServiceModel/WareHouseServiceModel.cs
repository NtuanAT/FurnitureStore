using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceModel
{
	public class WareHouseServiceModel
	{
		public Guid WareHouseID { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public Account Admin { get; set; }
		public List<InStoreProduct> products { get; set; }
	}
}
