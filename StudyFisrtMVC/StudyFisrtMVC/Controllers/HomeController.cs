using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyFisrtMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            ViewBag.time = DateTime.Now.Day;
            return View();
        }
        
        public ViewResult Inviteform()
        {
            return View();
        }
    }
}