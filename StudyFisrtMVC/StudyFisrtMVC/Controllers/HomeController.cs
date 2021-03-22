using StudyFisrtMVC.Models;
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
        [HttpGet]
        public ViewResult Inviteform()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Inviteform(Guests guests)
        {
            if (ModelState.IsValid)
            {
            return View("thanks",guests);

            }
            else
            {
                return View();
            }
        }
    }
}