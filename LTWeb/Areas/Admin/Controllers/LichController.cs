using Model.Dao;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class LichController : BaseController
    {
        // GET: Admin/Lich
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new LichDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CapDau idcd)
        {
            if (ModelState.IsValid)
            {
                var dao = new LichDao();
                long id = dao.Insert(idcd);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Lich");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var giai = new LichDao().ViewDetail(id);
            return View(giai);
        }
        [HttpPost]
        public ActionResult Edit(CapDau giai)
        {
            if (ModelState.IsValid)
            {
                var cd = new LichDao();
                bool result = cd.Update(giai);
                if (result)
                {
                    return RedirectToAction("Index", "Lich");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new LichDao().Delete(id);
            return RedirectToAction("Index", "Lich");
        }
    }
}