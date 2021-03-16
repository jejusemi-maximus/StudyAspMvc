using SportStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepo)
        {
            repository = productRepo;
        }
        // GET: Product
        public ActionResult List()
        {
            return View(repository.Products);
        }
    }
}