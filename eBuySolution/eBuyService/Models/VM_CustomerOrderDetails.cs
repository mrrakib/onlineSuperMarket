using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class VM_CustomerOrderDetails
    {
        [Key]
        public int CustomerID { get; set; }
       
        public string First_Name { get; set; }
      
        public string Last_Name { get; set; }
       
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
        public int OrderID { get; set; }
        public int? Discount { get; set; }
        public int? Taxes { get; set; }
        public int? TotalAmount { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? DIspatched { get; set; }
        public DateTime? DispatchedDate { get; set; }
        public bool? Shipped { get; set; }
        public DateTime? ShippingDate { get; set; }
        public bool? Deliver { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool? CancelOrder { get; set; }




    }
}