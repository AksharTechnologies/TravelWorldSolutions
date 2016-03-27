using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelWorldSolutions.Filters
{
    public class LoginSecurity:IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null && (filterContext.RouteData.Values["controller"].ToString() != "Login" && filterContext.RouteData.Values["action"].ToString() != "Indexs"))
            {
                filterContext.HttpContext.Response.RedirectToRoute("Login");
            }
            //throw new NotImplementedException();
        }
    }
}