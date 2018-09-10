using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using eBuyService.Models;
using System.Web.Http.Cors;

namespace eBuyService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using eBuyService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Category>("Categories"); 
    builder.EntitySet<OrderDetail>("OrderDetails"); 
    builder.EntitySet<Review>("Reviews"); 
    builder.EntitySet<SubCategory>("SubCategories"); 
    builder.EntitySet<Supplier>("Suppliers"); 
    builder.EntitySet<Wishlist>("Wishlists"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors("*","*", "*")]
    public class ProductsController : ODataController
    {
        private eBuyContext db = new eBuyContext();

        // GET: odata/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: odata/Products(5)
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(product => product.ProductID == key));
        }

        // PUT: odata/Products(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Put(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // POST: odata/Products
        public async Task<IHttpActionResult> Post(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return Created(product);
        }

        // PATCH: odata/Products(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Product> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            patch.Patch(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(product);
        }

        // DELETE: odata/Products(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Product product = await db.Products.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Products(5)/Category
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(m => m.ProductID == key).Select(m => m.Category));
        }

        // GET: odata/Products(5)/OrderDetails
        [EnableQuery]
        public IQueryable<OrderDetail> GetOrderDetails([FromODataUri] int key)
        {
            return db.Products.Where(m => m.ProductID == key).SelectMany(m => m.OrderDetails);
        }

        // GET: odata/Products(5)/Reviews
        [EnableQuery]
        public IQueryable<Review> GetReviews([FromODataUri] int key)
        {
            return db.Products.Where(m => m.ProductID == key).SelectMany(m => m.Reviews);
        }

        // GET: odata/Products(5)/SubCategory
        [EnableQuery]
        public SingleResult<SubCategory> GetSubCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(m => m.ProductID == key).Select(m => m.SubCategory));
        }

        // GET: odata/Products(5)/Supplier
        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(m => m.ProductID == key).Select(m => m.Supplier));
        }

        // GET: odata/Products(5)/Wishlists
        [EnableQuery]
        public IQueryable<Wishlist> GetWishlists([FromODataUri] int key)
        {
            return db.Products.Where(m => m.ProductID == key).SelectMany(m => m.Wishlists);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int key)
        {
            return db.Products.Count(e => e.ProductID == key) > 0;
        }
    }
}
