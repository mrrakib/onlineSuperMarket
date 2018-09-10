using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using eBuyService.Models;

namespace eBuyService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<OrderDetail>("OrderDetails");
            builder.EntitySet<Review>("Reviews");
            builder.EntitySet<SubCategory>("SubCategories");
            builder.EntitySet<Supplier>("Suppliers");
            builder.EntitySet<Wishlist>("Wishlists");
            builder.EntitySet<VM_CustomerOrderDetails>("VM_CustomerOrderDetails");
            builder.EntitySet<VM_ProductCategory>("VM_ProductCategory");
            builder.EntitySet<VM_SubCategory>("VM_SubCategory");
            builder.EntitySet<UserDetails>("UserDetails");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
