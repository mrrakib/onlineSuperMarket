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
    builder.EntitySet<VM_CustomerOrderDetails>("VM_CustomerOrderDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class VM_CustomerOrderDetailsController : ODataController
    {
    //    private eBuyContext db = new eBuyContext();

    //    // GET: odata/VM_CustomerOrderDetails
    //    [EnableQuery]
    //    public IQueryable<VM_CustomerOrderDetails> GetVM_CustomerOrderDetails()
    //    {
    //        return db.VM_CustomerOrderDetails;
    //    }

    //    // GET: odata/VM_CustomerOrderDetails(5)
    //    [EnableQuery]
    //    public SingleResult<VM_CustomerOrderDetails> GetVM_CustomerOrderDetails([FromODataUri] int key)
    //    {
    //        return SingleResult.Create(db.VM_CustomerOrderDetails.Where(vM_CustomerOrderDetails => vM_CustomerOrderDetails.CustomerID == key));
    //    }

    //    // PUT: odata/VM_CustomerOrderDetails(5)
    //    public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<VM_CustomerOrderDetails> patch)
    //    {
    //        Validate(patch.GetEntity());

    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        VM_CustomerOrderDetails vM_CustomerOrderDetails = await db.VM_CustomerOrderDetails.FindAsync(key);
    //        if (vM_CustomerOrderDetails == null)
    //        {
    //            return NotFound();
    //        }

    //        patch.Put(vM_CustomerOrderDetails);

    //        try
    //        {
    //            await db.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!VM_CustomerOrderDetailsExists(key))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return Updated(vM_CustomerOrderDetails);
    //    }

    //    // POST: odata/VM_CustomerOrderDetails
    //    public async Task<IHttpActionResult> Post(VM_CustomerOrderDetails vM_CustomerOrderDetails)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        db.VM_CustomerOrderDetails.Add(vM_CustomerOrderDetails);
    //        await db.SaveChangesAsync();

    //        return Created(vM_CustomerOrderDetails);
    //    }

    //    // PATCH: odata/VM_CustomerOrderDetails(5)
    //    [AcceptVerbs("PATCH", "MERGE")]
    //    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<VM_CustomerOrderDetails> patch)
    //    {
    //        Validate(patch.GetEntity());

    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        VM_CustomerOrderDetails vM_CustomerOrderDetails = await db.VM_CustomerOrderDetails.FindAsync(key);
    //        if (vM_CustomerOrderDetails == null)
    //        {
    //            return NotFound();
    //        }

    //        patch.Patch(vM_CustomerOrderDetails);

    //        try
    //        {
    //            await db.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!VM_CustomerOrderDetailsExists(key))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return Updated(vM_CustomerOrderDetails);
    //    }

    //    // DELETE: odata/VM_CustomerOrderDetails(5)
    //    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    //    {
    //        VM_CustomerOrderDetails vM_CustomerOrderDetails = await db.VM_CustomerOrderDetails.FindAsync(key);
    //        if (vM_CustomerOrderDetails == null)
    //        {
    //            return NotFound();
    //        }

    //        db.VM_CustomerOrderDetails.Remove(vM_CustomerOrderDetails);
    //        await db.SaveChangesAsync();

    //        return StatusCode(HttpStatusCode.NoContent);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool VM_CustomerOrderDetailsExists(int key)
    //    {
    //        return db.VM_CustomerOrderDetails.Count(e => e.CustomerID == key) > 0;
    //    }
    }
}
