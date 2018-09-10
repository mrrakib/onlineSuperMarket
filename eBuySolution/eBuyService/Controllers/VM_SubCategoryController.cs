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
    builder.EntitySet<VM_SubCategory>("VM_SubCategory");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class VM_SubCategoryController : ODataController
    {
        private eBuyContext db = new eBuyContext();

        // GET: odata/VM_SubCategory
        [EnableQuery]
        public IQueryable<VM_SubCategory> GetVM_SubCategory()
        {
            return from s in db.SubCategories
                   join c in db.Categories on s.CategoryID equals c.CategoryID

                   select (new VM_SubCategory
                   {

                       SubCategoryID = s.SubCategoryID,
                       SubCategoryName = s.SubCategoryName,
                       CategoryName = c.CategoryName,
                       Description=s.Description,
                       Picture=s.Picture


                   });
        }

        // GET: odata/VM_SubCategory(5)
        [EnableQuery]
        public SingleResult<VM_SubCategory> GetVM_SubCategory([FromODataUri] int key)
        {
            return SingleResult.Create(from s in db.SubCategories where s.SubCategoryID == key
                                       join c in db.Categories on s.CategoryID equals c.CategoryID

                                       select (new VM_SubCategory
                                       {

                                           SubCategoryID = s.SubCategoryID,
                                           SubCategoryName = s.SubCategoryName,
                                           CategoryName = c.CategoryName,
                                           Description = s.Description,
                                           Picture = s.Picture


                                       }));
        }

        //// PUT: odata/VM_SubCategory(5)
        //public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<VM_SubCategory> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    VM_SubCategory vM_SubCategory = await db.VM_SubCategory.FindAsync(key);
        //    if (vM_SubCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(vM_SubCategory);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VM_SubCategoryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(vM_SubCategory);
        //}

        //// POST: odata/VM_SubCategory
        //public async Task<IHttpActionResult> Post(VM_SubCategory vM_SubCategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.VM_SubCategory.Add(vM_SubCategory);
        //    await db.SaveChangesAsync();

        //    return Created(vM_SubCategory);
        //}

        //// PATCH: odata/VM_SubCategory(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<VM_SubCategory> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    VM_SubCategory vM_SubCategory = await db.VM_SubCategory.FindAsync(key);
        //    if (vM_SubCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(vM_SubCategory);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VM_SubCategoryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(vM_SubCategory);
        //}

        //// DELETE: odata/VM_SubCategory(5)
        //public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        //{
        //    VM_SubCategory vM_SubCategory = await db.VM_SubCategory.FindAsync(key);
        //    if (vM_SubCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    db.VM_SubCategory.Remove(vM_SubCategory);
        //    await db.SaveChangesAsync();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool VM_SubCategoryExists(int key)
        //{
        //    return db.VM_SubCategory.Count(e => e.SubCategoryID == key) > 0;
        //}
    }
}
