using LanguageFeatures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "es,es,e,se";
        }

        public ActionResult AutoProperty()
        {
            Products products = new Products();
            products.Name = "it";
            string Pname = products.Name;
            return View("Result",(object)Pname);
        }

        public ViewResult CreateProduct()
        {
            Products product = new Products();

        }
    }
}