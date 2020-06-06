using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class TournamentController : BaseController
    {
        // GET: Admin/Tournament
        public ActionResult Index(int page=1, int pageSize=10)
        {
            var dao = new TournamentDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GiaiDau idgiai)
        {
            if (ModelState.IsValid)
            {
                var dao = new TournamentDao();
                long id = dao.Insert(idgiai);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Tournament");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm giải đấu thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var giai = new TournamentDao().ViewDetail(id);
            return View(giai);
        }
        [HttpPost]
        public ActionResult Edit(GiaiDau giai)
        {
            if (ModelState.IsValid)
            {
                var dao = new TournamentDao();
                bool result = dao.Update(giai);
                if (result)
                {
                    return RedirectToAction("Index", "Tournament");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật giải đấu thất bại");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new TournamentDao().Delete(id);
            return RedirectToAction("Index", "Tournament");
        }
    }
}