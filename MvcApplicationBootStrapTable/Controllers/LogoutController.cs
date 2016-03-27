using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWorldSolutions.Controllers
{
    public class LogoutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
