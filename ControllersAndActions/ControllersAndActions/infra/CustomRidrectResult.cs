using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControllersAndActions.infra
{
    public class CustomRidrectResult : ActionResult
    {
        public string url { get; set; }
        public override void ExecuteResult(ControllerContext context)
        {
            string fullUrl = UrlHelper.GenerateContentUrl(url, context.HttpContext);
            context.HttpContext.Response.Redirect(fullUrl);
        }
    }
}