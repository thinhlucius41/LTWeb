using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace LTWeb.Controllers
{
    public class ClubsInfoController : Controller
    {
        // GET: ClubsInfo
        public ActionResult Index()
        {
            LTWebDataContext db = new LTWebDataContext();
            var d = from m in db.CLBs
                    where m.hide == true
                    orderby m.IDclb descending
                    select m;
            return View(d);
        }
        [ValidateInput(false)]
        public ActionResult Details(long id)
        {
            var dao = new ClubsDao();
            var i = dao.GetById(id);
            return PartialView(i);
        }
    }
}