using LTWeb.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace LTWeb.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString,int page =1,int pageSize = 1)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var dao = new UserDao();
            var user = dao.ViewDetail(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new UserDao();
            ViewBag.Role = new SelectList(dao.ListAll(), "Id_role ", "TenRole", selectedId);
        }
        [HttpPost]
        public ActionResult Create(user User)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();                
                var encryptedMD5Pass = Encryptor.MD5Hash(User.MK); // đọc mã hóa và mã hóa mật khẩu
                User.MK = encryptedMD5Pass;
                User.Role = 1;
                long id = dao.Insert(User);
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var User = new UserDao().ViewDetail(id);
            SetViewBag();
            return View(User);
        }
        [HttpPost]
        public ActionResult Edit(user User)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();               
                if (!string.IsNullOrEmpty(User.MK))
                {
                    var encryptedMD5Pass = Encryptor.MD5Hash(User.MK); // đọc mã hóa và mã hóa mật khẩu
                    User.MK = encryptedMD5Pass;                  
                }
                bool result = dao.Update(User);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thất bại");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index","User");
        }
    }
}