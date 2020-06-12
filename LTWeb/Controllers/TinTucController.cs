using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace LTWeb.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FirstNews()
        {
            LTWebDataContext db = new LTWebDataContext();
            var d = from m in db.News
                    where m.hide == true
                    orderby m.IDnews descending
                    select m;
            return PartialView(d.First());
        }
    }
}