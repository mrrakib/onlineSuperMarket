using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBuyService.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalePrice { get; set; }

        public int? SaleQuantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalSale { get; set; }
        public int? ProductID { get; set; }
        public int? OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}