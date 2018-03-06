using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Idea_Collecting_System.Customs;

namespace Idea_Collecting_System.Controllers
{
    [CustomAuthorize(Roles =  "Admin,QAC,QAM")]
    public class ManagerController : Controller
    {
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }

}