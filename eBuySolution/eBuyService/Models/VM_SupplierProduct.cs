using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class VM_SupplierProduct
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
       
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }


    }
}