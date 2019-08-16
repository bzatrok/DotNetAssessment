using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProductApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product",
                url: "product/index/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{pageNumber}/{keyword}",
                defaults: new { controller = "Home", action = "Index", pageNumber = UrlParameter.Optional, keyword = UrlParameter.Optional }
            );
        }
    }
}
