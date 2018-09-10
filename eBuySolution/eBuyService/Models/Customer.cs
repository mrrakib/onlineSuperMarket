using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eBuyService.Models
{
    public partial class Customer
    {
        public Customer()
        {
            //this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();
            this.Wishlists = new HashSet<Wishlist>();
        }

        public int CustomerID { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string Picture { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? Created { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
      
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }

    }
}