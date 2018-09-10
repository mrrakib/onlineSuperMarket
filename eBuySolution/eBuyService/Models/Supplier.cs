using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eBuyService.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}