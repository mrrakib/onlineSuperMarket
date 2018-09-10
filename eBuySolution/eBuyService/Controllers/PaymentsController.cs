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

namespace eBuyService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using eBuyService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Payment>("Payments");
    builder.EntitySet<Order>("Orders"); 
    builder.EntitySet<PaymentType>("PaymentTypes"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class PaymentsController : ODataController
    {
        private eBuyContext db = new eBuyContext();

        // GET: odata/Payments
        [EnableQuery]
        public IQueryable<Payment> GetPayments()
        {
            return db.Payments;
        }

        // GET: odata/Payments(5)
        [EnableQuery]
        public SingleResult<Payment> GetPayment([FromODataUri] int key)
        {
            return SingleResult.Create(db.Payments.Where(payment => payment.PaymentID == key));
        }

        // PUT: odata/Payments(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Payment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            patch.Put(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(payment);
        }

        // POST: odata/Payments
        public async Task<IHttpActionResult> Post(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payments.Add(payment);
            await db.SaveChangesAsync();

            return Created(payment);
        }

        // PATCH: odata/Payments(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Payment> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            patch.Patch(payment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(payment);
        }

        // DELETE: odata/Payments(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Payment payment = await db.Payments.FindAsync(key);
            if (payment == null)
            {
                return NotFound();
            }

            db.Payments.Remove(payment);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Payments(5)/Orders
        //[EnableQuery]
        //public IQueryable<Order> GetOrders([FromODataUri] int key)
        //{
        //    return db.Payments.Where(m => m.PaymentID == key).SelectMany(m => m.Orders);
        //}

        // GET: odata/Payments(5)/PaymentType
        [EnableQuery]
        public SingleResult<PaymentType> GetPaymentType([FromODataUri] int key)
        {
            return SingleResult.Create(db.Payments.Where(m => m.PaymentID == key).Select(m => m.PaymentType));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PaymentExists(int key)
        {
            return db.Payments.Count(e => e.PaymentID == key) > 0;
        }
    }
}
