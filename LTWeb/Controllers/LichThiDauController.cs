using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Model.Dao;
namespace LTWeb.Controllers
{
    public class LichThiDauController : Controller
    {
        public ActionResult LichDau(long idlich, long idcd)
        {
            var dao = new MatchDao();
            var i = dao.ListLichThiDau(idlich,idcd);

            return PartialView(i.ToList());
        }
        public ActionResult hienthiLichDau(long id)
        {
            var dao = new MatchDao();
            var i = dao.GetByIDLich(id);

            return PartialView(i);
        }
    }
}