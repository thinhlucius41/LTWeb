using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb.Areas.Admin.Models;
using Model.Dao;
using LTWeb.Common;

namespace LTWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName,Encryptor.MD5Hash(model.PassWord));
                if (result==1)
                {
                    var uSer = dao.GetById(model.UserName);
                    var userSESSION = new UserLogin();
                    userSESSION.UserName = uSer.TK;
                    userSESSION.UserID = uSer.IDuser;
                    Session.Add(CommonConstants.USER_SESSION, userSESSION);
                    return RedirectToAction("Index", "Default");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if(result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else 
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("Index");
        }
    }
}