using LTWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Controllers
{
    public class CusLoginController : Controller
    {
        // GET: CusLogin
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION]; // Kiểm tra nếu đăng nhập chưa
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { Controller = "HomeLogin", Action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}