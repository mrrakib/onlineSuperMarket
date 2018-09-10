using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public partial class Stock
    {
        public int ProductID { get; set; }
        
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }
        public int? UnitInStock { get; set; }
        public int? UnitInDelivered { get; set; }
        public int? TotalQuantity { get; set; }




        public virtual Product Product  { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}