using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Filters.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password, string returnUrl)
        {
            bool result = FormsAuthentication.Authenticate(name, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(name, false);
                return Redirect(returnUrl ?? Url.Action("Index", "Admin"));

            }
            else
            {
                ModelState.AddModelError("", "아이디와 비밀번호를 확인하세요!");
                return View();
            }
        }
    }
}