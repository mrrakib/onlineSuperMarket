using System.Collections.Generic;

namespace eBuyService.Models
{
    public partial class Category
    {
        public Category()
        {
            
            this.Products = new HashSet<Product>();
            this.SubCategories = new HashSet<SubCategory>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool? IsActive { get; set; }

        
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}