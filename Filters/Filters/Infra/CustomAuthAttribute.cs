using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infra
{
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        private bool localAllow;
        public CustomAuthAttribute(bool allowParam)
        {
            localAllow = allowParam;
        }

        protected override bool AuthorizeCore(HttpContextBase Context)
        {
            if (Context.Request.IsLocal)
            {
                return localAllow;
            }
            else
            {
                return true;
            }
        }
    }
}