using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetAssessment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute("search", "home/{searchText}/{page}", new { controller = "Home", action = "Search", searchText = UrlParameter.Optional, page = UrlParameter.Optional, id = "" }, new string[] { "DotNetAssessment.Controllers" });
            //routes.MapRoute("detail", "product-detail/{sku}", new { controller = "Home", action = "ProductDetail", sku = UrlParameter.Optional, id = "" });
            routes.MapRoute(
                name: "home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}