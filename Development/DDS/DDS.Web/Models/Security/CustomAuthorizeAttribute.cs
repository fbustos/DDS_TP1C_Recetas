using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace DDS.Models.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                base.OnAuthorization(filterContext); //returns to login url
            }
        }
    }
}