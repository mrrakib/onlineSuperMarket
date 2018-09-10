using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Reviews = new HashSet<Review>();
            this.Wishlists = new HashSet<Wishlist>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int? SubCategoryID { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal? OldPrice { get; set; }

        public string Size { get; set; }
        public decimal? Discount { get; set; }

        public int? UnitOnOrder { get; set; }
        public bool? ProductAvailable { get; set; }
        public string ImageURL { get; set; }
        public string AltText { get; set; }
        public bool? AddBadge { get; set; }
        public string OfferTitle { get; set; }
        public string OfferBadgeClass { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public int? Quantity { get; set; }

        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
    }
}