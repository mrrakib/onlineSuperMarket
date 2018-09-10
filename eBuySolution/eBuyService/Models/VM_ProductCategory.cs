using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class VM_ProductCategory
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }


        public int? SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public int? Quantity { get; set; }

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
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
    }
}