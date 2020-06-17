using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
namespace LTWeb.Models
{
    public class RegisterDao
    {
        LTWebDataContext db = null;
        public RegisterDao()
        {
            db = new LTWebDataContext();
        }
        public long Insert(user entity)
        {
            entity.dateBegin = DateTime.Now;
            entity.Role = 2;
            entity.hide = true;
            db.users.Add(entity);
            db.SaveChanges();
            return entity.IDuser;
        }
        public user GetById(string userName)
        {
            return db.users.SingleOrDefault(x => x.TK == userName);
        }

        public user ViewDetail(int ID)
        {
            return db.users.Find(ID);
        }

        public bool Update(user entity)
        {
            try
            {
                var user = db.users.Find(entity.IDuser);
                if (!string.IsNullOrEmpty(entity.MK))
                {
                    user.MK = entity.MK;
                }
                user.mail = entity.mail;
                user.sdt = entity.sdt;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int HomeLogin(string Username, string Password)
        {
            var result = db.users.SingleOrDefault(x => x.TK == Username);
            if (result == null) // kt nếu tài khoản có tồn tại
            {
                return 0;
            }
            else
            {
                if (result.hide == false) // nếu hide = false thì username đang bị khóa;
                {
                    return -1;
                }
                else if (result.MK == Password) // nếu mật khẩu đúng và đúng tài khoản admin
                {
                    return 1;
                }
                else if (result.MK != Password)                      // nếu mật khẩu sai
                {
                    return -2;
                }
                else
                {
                    return -3;
                }
            }
        }
    }
}