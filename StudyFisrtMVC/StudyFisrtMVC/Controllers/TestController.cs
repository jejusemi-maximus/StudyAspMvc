using StudyFisrtMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyFisrtMVC.Controllers
{
    public class TestController : Controller
    {
        private IUserRepo repository;

        public TestController(IUserRepo repo)
        {
            repository = repo;
        }

        public ActionResult ChangeLoginName(string OldName, string NewName)
        {
            User user = repository.FetchByLoginName(OldName);
            user.LoginName = NewName;
            repository.SubmitChange();
            return View();
        }

        
    }

}