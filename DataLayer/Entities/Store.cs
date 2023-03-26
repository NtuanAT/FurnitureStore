using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Store
	{
		[Key]
		public Guid StoreID { get; set; }
		[Required(ErrorMessage = "Store's name is required"), MinLength(5, ErrorMessage = "Store's name has to be between 5 and 20 character"), MaxLength(20, ErrorMessage = "Store's name has to be between 5 and 20 character")]
		public string StoreName { get; set; }
		public Guid StoreAdminAccountID { get; set; }
        public Account StoreAdmin { get; set; }
		public List<Account> Staffs { get; set; }
		public List <InStoreProduct> Products { get; set; }

		[Required]
		public string Location { get; set; }
		public StoreStatus Status { get; set; }
	}

	public enum StoreStatus
	{
		Open,
		Close
	}

}
