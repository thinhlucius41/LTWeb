using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedBackDao
    {
        LTWebDataContext db = null;
        public FeedBackDao()
        {
            db = new LTWebDataContext();
        }
        public long Insert(LienHe entity)
        {
            db.LienHes.Add(entity);
            db.SaveChanges();
            return entity.ID_Contract;
        }
        public IEnumerable<LienHe> ListAllPaging(int page, int pageSize)
        {
            return db.LienHes.OrderBy(x => x.ID_Contract).ToPagedList(page, pageSize);
        }

        public LienHe GetById(long ID)
        {
            return db.LienHes.SingleOrDefault(x => x.ID_Contract == ID);
        }

        public LienHe ViewDetail(long iD)
        {
            return db.LienHes.Find(iD);
        }
        

        public bool Update(LienHe entity)
        {
            try
            {
                var item = db.LienHes.Find(entity.ID_Contract);
                item.Ten = entity.Ten;
                item.NoiDung = entity.NoiDung;
                item.hide = entity.hide;
                item.Email = entity.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var Menu = db.menus.Find(id);
                db.menus.Remove(Menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
