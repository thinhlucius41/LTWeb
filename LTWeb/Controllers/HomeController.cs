using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace LTWeb.Controllers
{
    public class HomeController : Controller
    {
        LTWebDataContext db = new LTWebDataContext();
        public ActionResult Index(string meta)
        {
            var v = from t in db.menus
                    where t.meta == meta
                    select t;

            return PartialView(v.FirstOrDefault());
        }
        public ActionResult Menu()
        {
            var v = from m in db.menus
                    where m.idparent == 0 && m.hide == true
                    orderby m.no_ ascending
                    select m;
            return PartialView(v.ToList());
        }
        public PartialViewResult DropDownMenu(long Id)
        {
            var v = from m in db.menus
                    where m.idparent == Id && m.hide == true
                    orderby m.no_ ascending
                    select m;
            return PartialView(v.ToList());
        }
    }
}