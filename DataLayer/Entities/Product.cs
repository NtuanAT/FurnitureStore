using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Product
	{
		[Key]
		public Guid ProductID { get; set; }
		public string ProductName { get; set; }
		public string Category { get; set; }
		public double Price { get; set; }
		public List<InStoreProduct> InStoreProducts { get; set; }
	}

}
