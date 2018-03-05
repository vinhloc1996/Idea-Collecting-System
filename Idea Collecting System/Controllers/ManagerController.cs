using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Idea_Collecting_System.Customs;

namespace Idea_Collecting_System.Controllers
{
    public class ManagerController : Controller
    {
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }

//        [CustomAuthorize(Roles = "Admin,QAC,QAM")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }

}