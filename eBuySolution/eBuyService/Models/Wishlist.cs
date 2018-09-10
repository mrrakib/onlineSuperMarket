namespace eBuyService.Models
{
     public partial class Wishlist
    {
        public int WishlistID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public bool? IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}