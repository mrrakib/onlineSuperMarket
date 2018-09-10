using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public class VM_SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }
}