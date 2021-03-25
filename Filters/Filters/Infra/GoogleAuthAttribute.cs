using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Filters.Infra
{
    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;
            //인증되지 않았을 경우
            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //인증이 되지 않았을 경우 새로 Result를 만들어줌.
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"controller","GoogleAccount" },
                    {"action","Login" },
                    {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                });
            }
        }
    }
}