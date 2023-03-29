using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public Guid CustomerID { get; set; }
        public Account Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        List<InStoreProduct> Products { get; set; }
        public OrderStatus Status { get; set; }


    }

    public enum OrderStatus
    {
        Pending,
        CheckedOut,
        OnDelivery,
        Completed,
        Cancelled
    }
}
