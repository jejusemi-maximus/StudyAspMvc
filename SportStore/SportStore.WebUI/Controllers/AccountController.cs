using SportStore.WebUI.Infra.Abstract;
using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider provider)
        {
            authProvider = provider;
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Name, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("index", "Admin"));
                }else
                {
                    ModelState.AddModelError("", "비밀번호를 확인하세요!");
                    return View();
                }
            }else
            {
                return View();
            }
        }
    }
}