using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        // GET: Admin/News
        public ActionResult Index(string searchString,int page =1,int pageSize=10)
        {
            var dao = new NewsDao();
            var tintin = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(tintin);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(News id)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
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
        public ActionResult Edit(long ID)
        {
            var tintuc = new NewsDao().ViewDetail(ID);
            return View(tintuc);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(News paper)
        {
            if (ModelState.IsValid)
            {
                var dao = new NewsDao();
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