using System.Web.Mvc;

namespace Idea_Collecting_System.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Manager";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manager_default",
                "Manager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new [] { "Idea_Collecting_System.Areas.Manager.Controllers" }
            );
        }
    }
}