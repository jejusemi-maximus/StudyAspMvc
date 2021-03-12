using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyFisrtMVC.Controllers
{
    public class TestController : Controller
    {
        private IUserRepo repo;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}