using System;
using System.Web;
using System.Web.Mvc;

namespace Idea_Collecting_System.Customs
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

        }
    }
}