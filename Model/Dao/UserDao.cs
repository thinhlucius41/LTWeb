using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        LTWebDataContext db = null;
        public UserDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(user entity)
        {
            db.users.Add(entity);
            db.SaveChanges();
            return entity.IDuser;
        }

        public IEnumerable<user> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<user> model = db.users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TK.Contains(searchString));
            }

            return model.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }
        public List<Role> ListAll()
        {
            return db.Roles.ToList();
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
                user.Role = entity.Role;
                user.hide = entity.hide;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public int Login(string Username,string Password)
        {
            var result = db.users.SingleOrDefault(x => x.TK == Username);
            if(result == null) // kt nếu tài khoản có tồn tại
            {
                return 0;
            }
            else
            {
                if(result.hide == false) // nếu hide = false thì username đang bị khóa;
                {
                    return -1;  
                }
                else if(result.MK == Password && result.Role == 1) // nếu mật khẩu đúng và đúng tài khoản admin
                {
                    return 1;
                }
                else                       // nếu mật khẩu sai
                {
                    return -2;
                }
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
                else if (result.MK == Password ) // nếu mật khẩu đúng và đúng tài khoản admin
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
        public bool Delete(int id)
        {
            try
            {
                var User = db.users.Find(id);
                db.users.Remove(User);
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
