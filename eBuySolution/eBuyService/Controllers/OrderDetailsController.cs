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
    builder.EntitySet<OrderDetail>("OrderDetails");
    builder.EntitySet<Order>("Orders"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors("*", "*", "*")]
    public class OrderDetailsController : ODataController
    {
        private eBuyContext db = new eBuyContext();

        // GET: odata/OrderDetails
        [EnableQuery]
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            return db.OrderDetails;
        }

        // GET: odata/OrderDetails(5)
        [EnableQuery]
        public SingleResult<OrderDetail> GetOrderDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.OrderDetails.Where(orderDetail => orderDetail.OrderDetailId == key));
        }

        // PUT: odata/OrderDetails(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<OrderDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderDetail orderDetail = await db.OrderDetails.FindAsync(key);
            if (orderDetail == null)
            {
                return NotFound();
            }

            patch.Put(orderDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(orderDetail);
        }

        // POST: odata/OrderDetails
        public async Task<IHttpActionResult> Post(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderDetails.Add(orderDetail);
            await db.SaveChangesAsync();

            return Created(orderDetail);
        }

        // PATCH: odata/OrderDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<OrderDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderDetail orderDetail = await db.OrderDetails.FindAsync(key);
            if (orderDetail == null)
            {
                return NotFound();
            }

            patch.Patch(orderDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(orderDetail);
        }

        // DELETE: odata/OrderDetails(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            OrderDetail orderDetail = await db.OrderDetails.FindAsync(key);
            if (orderDetail == null)
            {
                return NotFound();
            }

            db.OrderDetails.Remove(orderDetail);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/OrderDetails(5)/Order
        [EnableQuery]
        public SingleResult<Order> GetOrder([FromODataUri] int key)
        {
            return SingleResult.Create(db.OrderDetails.Where(m => m.OrderDetailId == key).Select(m => m.Order));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDetailExists(int key)
        {
            return db.OrderDetails.Count(e => e.OrderDetailId == key) > 0;
        }
    }
}
