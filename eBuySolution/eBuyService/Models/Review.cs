using System;
using System.ComponentModel.DataAnnotations;

namespace eBuyService.Models
{
    public partial class Review
    {
        public int ReviewID { get; set; }
        public int? CustomerID { get; set; }
        public int? ProductID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Review1 { get; set; }
        public int? Rate { get; set; }
        public DateTime? DateTime { get; set; }
        public bool? isDelete { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}