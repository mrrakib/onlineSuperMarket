using System.Collections.Generic;

namespace eBuyService.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            this.Products = new HashSet<Product>();
        }

        public int SubCategoryID { get; set; }
        public int CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}