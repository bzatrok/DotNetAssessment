using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string id)
        {
            var validatedID = Server.HtmlEncode(id);

            SingleProductModel model = new SingleProductModel();

            return View(model);
        }
    }
}