using LTWeb.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}