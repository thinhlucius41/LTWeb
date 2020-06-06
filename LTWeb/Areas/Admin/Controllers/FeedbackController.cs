using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Admin/Feedback
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var dao = new FeedBackDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(LienHe id)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                long result = dao.Insert(id);
                if (result > 0)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm bài báo thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult ViewDetail(long ID)
        {
            var tintuc = new FeedBackDao().ViewDetail(ID);
            return View(tintuc);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ViewDetail(LienHe paper)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedBackDao();
                bool result = dao.Update(paper);
                if (result)
                {
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật bài báo thất bại");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new NewsDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}