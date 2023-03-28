using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	public class Account
	{
		[Key]
		public Guid AccountID { get; set; }
		[Required(ErrorMessage ="Username is required"), MinLength(5, ErrorMessage ="Username has to be between 5 and 20 character"), MaxLength(20, ErrorMessage = "Username has to be between 5 and 20 character")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Username is required"), MinLength(5, ErrorMessage = "Username has to be between 6 and 40 character"), MaxLength(20, ErrorMessage = "Username has to be between 6 and 40 character")]
		public string Password { get; set; }
		public AccountRole Role { get; set; }
		public int AccountStatus { get; set; }
        public Guid? StaffStoreID { get; set; }
        public Store StaffStore { get; set; }

        public Guid? AdminStoreID { get; set; }
        public Store AdminStore { get; set; }
    }

	public enum AccountRole
	{
		Admin,
		Staff,
		Customer
	}

	public enum AccountStatus
	{
		Active,
		Inactive
	}
}
