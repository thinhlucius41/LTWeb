using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace LTWeb.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index(string meta)
        {
            LTWebDataContext db = new LTWebDataContext();
            var d = from a in db.News
                    where a.meta == meta
                    select a;
            return View(d.FirstOrDefault());
        }
        [ChildActionOnly]
        public PartialViewResult FirstNews(string metatitle)
        {
            ViewBag.meta = metatitle;
            LTWebDataContext db = new LTWebDataContext();
            var d = from m in db.News
                    where m.hide == true 
                    orderby m.IDnews descending
                    select m;
            return PartialView(d.ToList());
        }
        [ValidateInput(false)]
        public ActionResult Details(long id)
        {
            var model = new NewsDao().ViewDetail(id);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult HomeListNews(string metatitle)
        {
            ViewBag.meta = metatitle;
            LTWebDataContext db = new LTWebDataContext();
            var d = from m in db.News
                    where m.hide == true 
                    select m;
            d.OrderByDescending(x => x.IDnews).Take(4);
            return PartialView(d.ToList());
        }
        public ActionResult PageNews(int page=1,int pagesize=5)
        {
            var dao = new NewsDao();
            var i = dao.ListAllPageNews(page, pagesize);

            return View(i);
        }

    }
}