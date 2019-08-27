using Assigment.BAL.Services.Products;
using Assigment.Infastrcture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Assigment
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>();
            config.DependencyResolver = new UnityResolver(container);


            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                 new { id = RouteParameter.Optional }
            );
        }
    }
}
