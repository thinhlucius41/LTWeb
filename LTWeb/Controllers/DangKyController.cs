using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using LTWeb.Common;
using LTWeb.Models;

namespace LTWeb.Controllers
{
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(user User)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();
                var encryptedMD5Pass = Encryptor.MD5Hash(User.MK); // đọc mã hóa và mã hóa mật khẩu
                User.MK = encryptedMD5Pass;
                long id = dao.Insert(User);
                if (id > 0)
                {
                    return RedirectToAction("Index", "HomeLogin");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thất bại");
                }
            }
            return View("Index");
        }
        public ActionResult Detail(int id)
        {
            var User = new RegisterDao().ViewDetail(id);
            return View(User);
        }
        public ActionResult Update(int id)
        {
            var User = new RegisterDao().ViewDetail(id);
            return View(User);
        }
        [HttpPost]
        public ActionResult Update(user User)
        {
            if (ModelState.IsValid)
            {
                var dao = new RegisterDao();
                if (!string.IsNullOrEmpty(User.MK))
                {
                    var encryptedMD5Pass = Encryptor.MD5Hash(User.MK); // đọc mã hóa và mã hóa mật khẩu
                    User.MK = encryptedMD5Pass;
                }
                bool result = dao.Update(User);
                if (result)
                {
                    return RedirectToAction("Update", "DangKy");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thất bại");
                }
            }
            return View("Detail", "DangKy");
        }
    }
}