using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndActions.Controllers
{
    public class BaseController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            string action = (string)requestContext.RouteData.Values["action"];

            requestContext.HttpContext.Response.Write(string.Format("컨트롤러 {0} , 액션 {1}", controller, action));

            if (action.ToLower() == "redirect")
            {
                requestContext.HttpContext.Response.Redirect("/Derived/Index/se");
            }
            else
            {
                requestContext.HttpContext.Response.Write(
                    string.Format("컨트롤러:{0}, 액션: {1}", controller, action));
            }
        }
    }
}