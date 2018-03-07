using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Idea_Collecting_System.Customs;

namespace Idea_Collecting_System.Areas.Manager.Controllers
{
    [CustomAuthorize(Roles = "Admin,QAC,QAM")]
    public class HomeController : CustomController
    {
        // GET: Manager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}