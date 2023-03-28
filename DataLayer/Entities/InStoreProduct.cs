using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class InStoreProduct
	{
		[Key]
		public Guid InStoreProductID { get; set; }
		public Guid ProductID { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public ProductStatus Status { get; set; }
	}


	public enum ProductStatus
	{
		OutOfStock,
		Active,
		InActive
	}
}
