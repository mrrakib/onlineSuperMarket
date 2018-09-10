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
using System.Web;
using System.IO;

namespace eBuyService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using eBuyService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SubCategory>("SubCategories");
    builder.EntitySet<Category>("Categories"); 
    builder.EntitySet<Product>("Products"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    //[EnableCors("*", "*", "*")]
    public class SubCategoriesController : ODataController
    {
        private eBuyContext db = new eBuyContext();

        // GET: odata/SubCategories
        [EnableQuery]
        public IQueryable<SubCategory> GetSubCategories()
        {
            return db.SubCategories;
        }

        // GET: odata/SubCategories(5)
        [EnableQuery]
        public SingleResult<SubCategory> GetSubCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.SubCategories.Where(subCategory => subCategory.SubCategoryID == key));
        }

        // PUT: odata/SubCategories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<SubCategory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategory subCategory = await db.SubCategories.FindAsync(key);
            if (subCategory == null)
            {
                return NotFound();
            }

            patch.Put(subCategory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subCategory);
        }

        // POST: odata/SubCategories
        public async Task<IHttpActionResult> Post(SubCategory subCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //getting the current request
            //HttpRequest request = HttpContext.Current.Request;

            ////getting parameter sended by client
            //HttpPostedFile subCatPic = (request.Files.Count > 0) ? request.Files[0] : null;
            //var categoryId = HttpContext.Current.Request.Form["CategoryID"];
            //var subCatName = request.Params["SubCategoryName"];
            //var description = request.Params["Description"];

            ////saving the image path into picture column and samve the image file in Images folder
            //if (subCatPic != null)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(subCatPic.FileName);
            //    string fileExt = Path.GetExtension(subCatPic.FileName);
            //    string imgPath = "~/Images/";

            //    if (!Directory.Exists(imgPath))
            //    {
            //        Directory.CreateDirectory(imgPath);
            //    }

            //    fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExt;
            //    subCategory.Picture = imgPath + fileName;
            //    fileName = Path.Combine(HttpContext.Current.Server.MapPath(imgPath), fileName);

            //    //saving the image into directory
            //    subCatPic.SaveAs(fileName);
            //}
            //subCategory.CategoryID = int.Parse(categoryId);
            //subCategory.SubCategoryName = subCatName;
            //subCategory.Description = description;

            db.SubCategories.Add(subCategory);
            await db.SaveChangesAsync();

            return Created(subCategory);
        }

        // PATCH: odata/SubCategories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SubCategory> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategory subCategory = await db.SubCategories.FindAsync(key);
            if (subCategory == null)
            {
                return NotFound();
            }

            patch.Patch(subCategory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subCategory);
        }

        // DELETE: odata/SubCategories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            SubCategory subCategory = await db.SubCategories.FindAsync(key);
            if (subCategory == null)
            {
                return NotFound();
            }

            db.SubCategories.Remove(subCategory);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/SubCategories(5)/Category
        [EnableQuery]
        public SingleResult<Category> GetCategory([FromODataUri] int key)
        {
            return SingleResult.Create(db.SubCategories.Where(m => m.SubCategoryID == key).Select(m => m.Category));
        }

        // GET: odata/SubCategories(5)/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.SubCategories.Where(m => m.SubCategoryID == key).SelectMany(m => m.Products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int key)
        {
            return db.SubCategories.Count(e => e.SubCategoryID == key) > 0;
        }
    }
}
