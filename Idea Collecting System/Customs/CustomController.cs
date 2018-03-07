using System.Linq;
using System.Web.Mvc;
using Idea_Collecting_System.Models;
using Microsoft.Ajax.Utilities;

namespace Idea_Collecting_System.Customs
{
    public class CustomController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                    if (user != null)
                        ViewData.Add("DisplayName", !user.FullName.IsNullOrWhiteSpace() ? user.FullName : user.UserName);
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}