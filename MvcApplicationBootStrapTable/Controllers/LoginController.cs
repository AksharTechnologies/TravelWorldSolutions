using TravelWorldSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TravelWorldSolutions.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (user.LoginId.ToLower()== "mrinal" && user.Password == "mrinal")
            {
                Session["user"] = user;
                return RedirectToAction("Index", "Default2");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
