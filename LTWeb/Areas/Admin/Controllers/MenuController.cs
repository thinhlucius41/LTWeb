using LTWeb.Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.Dao;

namespace LTWeb.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(int page=1,int pageSize =10)
        {
            var dao = new MenuDao();
            var model = dao.ListAllPaging( page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(menu idmenu)
        {

            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                long id = dao.Insert(idmenu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Menu thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var Menu = new MenuDao().ViewDetail(id);
            return View(Menu);
        }
        [HttpPost]
        public ActionResult Edit(menu Menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();
                bool result = dao.Update(Menu);
                if (result)
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật menu thất bại");
                }
            }
            return View("Index","Menu");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);
            return RedirectToAction("Index","Menu");
        }
    }
}