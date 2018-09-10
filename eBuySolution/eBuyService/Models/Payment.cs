using System;
using System.Collections.Generic;

namespace eBuyService.Models
{
    public partial class Payment
    {
        public Payment()
        {
            //this.Orders = new HashSet<Order>();
        }

        public int PaymentID { get; set; }
        public int Type { get; set; }
        public decimal? CreditAmount { get; set; }
        public decimal? DebitAmount { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? PaymentDateTime { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}