using EssentialTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalcuator calc;

        private Product[] Products =
        {
            new Product{Name="me",Category="soccer",Price=256m },
            new Product{Name="me1",Category="soccer",Price=256m },
            new Product{Name="me2",Category="soccer",Price=256m },
            new Product
            {Name="me3",Category="water",Price=512m }
        };

        public HomeController(IValueCalcuator calcParam)
        {
            calc = calcParam;
            
        }

        // GET: Home
        public ActionResult Index()
        {

            ShoppingCart cart = new ShoppingCart(calc) { prod = Products };

            decimal total = cart.SumTotal();


            return View(total);
        }
    }
}