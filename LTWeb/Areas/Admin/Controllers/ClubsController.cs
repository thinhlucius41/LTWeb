using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class ClubsController : BaseController
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
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CLB id,HttpPostedFileBase btnSelectImage)
        {
            var path = "";
            var filename = "";
            if (ModelState.IsValid)
            {
                if(btnSelectImage != null)
                {
                    filename = btnSelectImage.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/upload/files"),filename);
                    btnSelectImage.SaveAs(path);
                    id.Logo = filename;
                }
                var dao = new ClubsDao();
                long result = dao.Insert(id);
                if (result > 0)
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
        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(CLB giai, HttpPostedFileBase btnSelectImage)
        {
            var path = "";
            var filename = "";         
            if (ModelState.IsValid)
            {
                if (btnSelectImage != null)
                {
                    filename = btnSelectImage.FileName;
                    path = Path.Combine(Server.MapPath("~/Content/upload/files"),filename);
                    btnSelectImage.SaveAs(path);
                    giai.Logo = filename;
                }
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