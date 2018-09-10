using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class VM_SubCategoryProducts
    {
        [Key]
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }


    }
}