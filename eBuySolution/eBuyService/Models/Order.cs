using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int OrderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? GrandTotal { get; set; }
        public int? GrandTotalItem { get; set; }
        [StringLength(50)]
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        [StringLength(20)]
        public string CustomerPhone { get; set; }

        [StringLength(40)]
        public string CustomerEmail { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}