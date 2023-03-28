using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Warehouse
	{
		public Guid WareHouseID { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public Account Admin { get; set; }
	}
}
