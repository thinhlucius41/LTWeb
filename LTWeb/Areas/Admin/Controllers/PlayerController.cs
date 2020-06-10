using Model.EF;
using Model.Dao;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Admin/Player
        public ActionResult Index(int page =1, int pageSize=10)
        {
            var dao = new PlayerDao();
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
            var dao = new PlayerDao();
            ViewBag.IDclb = new SelectList(dao.ListAll(), "IDclb", "TenClb", selectedId);
        }
        [HttpPost]
        public ActionResult Create(CauThu idcauthu)
        {
            if (ModelState.IsValid)
            {
                var dao = new PlayerDao();
                long id = dao.Insert(idcauthu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "CauThus");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm cầu thủ thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(long id)
        {
            var giai = new PlayerDao().ViewDetail(id);
            SetViewBag();
            return View(giai);
        }
        [HttpPost]
        public ActionResult Edit(CauThu giai)
        {
            if (ModelState.IsValid)
            {
                var ct = new PlayerDao();
                bool result = ct.Update(giai);
                if (result)
                {
                    return RedirectToAction("Index", "CauThus");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật cầu thủ thất bại");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new ClubsDao().Delete(id);
            return RedirectToAction("Index", "CauThus");
        }
    }
}