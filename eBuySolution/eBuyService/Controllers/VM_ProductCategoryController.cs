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
    builder.EntitySet<VM_ProductCategory>("VM_ProductCategory");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class VM_ProductCategoryController : ODataController
    {
        private eBuyContext db = new eBuyContext();


        // GET: odata/VM_ProductCategory
        [EnableQuery]
        public IQueryable<VM_ProductCategory> GetVM_ProductCategory()
        {

            var query = from c in db.Categories
                        join p in db.Products
                        on c.CategoryID equals p.CategoryID join s in db.Suppliers on p.SupplierID equals s.SupplierID
                        join sub in db.SubCategories on p.SubCategoryID equals sub.SubCategoryID
                        select new VM_ProductCategory
                        {
                            ProductID = p.ProductID,
                            CategoryID = c.CategoryID,
                            CategoryName = c.CategoryName,
                            ProductName = p.ProductName,
                            Picture1 = p.Picture1,
                            UnitOnOrder = p.UnitOnOrder,
                            UnitPrice = p.UnitPrice,
                            SubCategoryName = sub.SubCategoryName,
                            CompanyName = s.CompanyName,
                            Quantity = p.Quantity,
                            OldPrice = p.OldPrice

                        };
            return query.AsQueryable();
        }

        //// GET: odata/VM_ProductCategory(5)
        [EnableQuery]
        public SingleResult<VM_ProductCategory> GetVM_ProductCategory([FromODataUri] int key)
        {
            return SingleResult.Create(from p in db.Products where p.ProductID == key
                                       join c in db.Categories
                                       on p.CategoryID equals c.CategoryID
                                       join s in db.Suppliers on p.SupplierID equals s.SupplierID
                                       join sub in db.SubCategories on p.SubCategoryID equals sub.SubCategoryID
                                       select new VM_ProductCategory
                                       {
                                           ProductID = p.ProductID,
                                           CategoryID = c.CategoryID,
                                           CategoryName = c.CategoryName,
                                           ProductName = p.ProductName,
                                           Picture1 = p.Picture1,
                                           UnitOnOrder = p.UnitOnOrder,
                                           UnitPrice = p.UnitPrice,
                                           SubCategoryName = sub.SubCategoryName,
                                           CompanyName = s.CompanyName,
                                           Quantity=p.Quantity,
                                           OldPrice=p.OldPrice

                                       });
        }

        //// PUT: odata/VM_ProductCategory(5)
        //public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<VM_ProductCategory> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    VM_ProductCategory vM_ProductCategory = await db.VM_ProductCategory.FindAsync(key);
        //    if (vM_ProductCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Put(vM_ProductCategory);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VM_ProductCategoryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(vM_ProductCategory);
        //}

        //// POST: odata/VM_ProductCategory
        //public async Task<IHttpActionResult> Post(VM_ProductCategory vM_ProductCategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.VM_ProductCategory.Add(vM_ProductCategory);
        //    await db.SaveChangesAsync();

        //    return Created(vM_ProductCategory);
        //}

        //// PATCH: odata/VM_ProductCategory(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<VM_ProductCategory> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    VM_ProductCategory vM_ProductCategory = await db.VM_ProductCategory.FindAsync(key);
        //    if (vM_ProductCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(vM_ProductCategory);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VM_ProductCategoryExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(vM_ProductCategory);
        //}

        //// DELETE: odata/VM_ProductCategory(5)
        //public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        //{
        //    VM_ProductCategory vM_ProductCategory = await db.VM_ProductCategory.FindAsync(key);
        //    if (vM_ProductCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    db.VM_ProductCategory.Remove(vM_ProductCategory);
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

        //private bool VM_ProductCategoryExists(int key)
        //{
        //    return db.VM_ProductCategory.Count(e => e.ProductID == key) > 0;
        //}
    }
}
