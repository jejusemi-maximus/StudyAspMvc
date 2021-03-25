using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filters.Infra;
namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuth(false)]
        public string Index()
        {
            return "나는 야 Maximus 라고 하지!";
        }
    }
}