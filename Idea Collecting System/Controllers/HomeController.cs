using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Idea_Collecting_System.Customs;

namespace Idea_Collecting_System.Controllers
{
    public class HomeController : Controller
    {
        //CustomAuthorize Work! Disable for developing index page
//        [CustomAuthorize(Roles = "Student,QAC,QAM")]
        //AllowAnonymous for developing stage only!
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}