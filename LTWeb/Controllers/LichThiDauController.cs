using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace LTWeb.Controllers
{
    public class LichThiDauController : Controller
    {
        LTWebDataContext db = new LTWebDataContext();
        // GET: LichThiDau
        public ActionResult ListDuelAComingNext(long id)
        {
            var list = from i in db.CapDaus
                       join a in db.CLBs on i.IDclbNha equals a.IDclb
                       where a.hide == true
                       select i;

            return PartialView(list);
        }
        public ActionResult ListDuelBComingNext(long id)
        {
            var list = from i in db.CLBs
                       join a in db.CapDaus on i.IDclb equals a.IDclbKhach
                       where i.hide == true
                       select i;
            return PartialView(list);
        }
        public ActionResult ListMacthComingNext(long id)
        {
            var list = from i in db.Liches
                       where i.hide == true
                       select i;

            return PartialView(list);
        }
        public ActionResult LichDau()
        {
            var list = from i in db.LichCapDaus
                       select i;

            return PartialView(list.ToList());
        }
    }
}