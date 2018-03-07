using System.Web.Mvc;

namespace Idea_Collecting_System.Customs
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            if(filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.User.IsInRole("Admin") && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home" && filterContext.HttpContext.Request.RequestContext.RouteData.DataTokens["area"] == null)
            {
                filterContext.Result = new RedirectResult("~/Manager/Home");
                return;
            }

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/AccessDenied");
                return;
            }
        }
    }
}