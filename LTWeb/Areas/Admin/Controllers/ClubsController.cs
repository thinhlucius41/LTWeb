using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Admin/Clubs
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new ClubsDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ClubsDao();
            ViewBag.IDGiai = new SelectList(dao.ListAll(), "IDGiai ", "TenGD", selectedId);
        }
        [HttpPost]
        public ActionResult Create(CLB idgiai)
        {
            if (ModelState.IsValid)
            {
                var dao = new ClubsDao();
                long id = dao.Insert(idgiai);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Clubs");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm CLB thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var giai = new ClubsDao().ViewDetail(id);
            SetViewBag();
            return View(giai);
        }
        [HttpPost]
        public ActionResult Edit(CLB giai)
        {
            if (ModelState.IsValid)
            {
                var clb = new ClubsDao();
                bool result = clb.Update(giai);
                if (result)
                {
                    return RedirectToAction("Index", "Clubs");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Club thất bại");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ClubsDao().Delete(id);
            return RedirectToAction("Index", "Clubs");
        }
    }
}