using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MenuDao
    {
        LTWebDataContext db = null;
        public MenuDao()
        {
            db = new LTWebDataContext();
        }
        public long Insert(menu entity)
        {
            db.menus.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public IEnumerable<menu> ListAllPaging(int page, int pageSize)
        {
            return db.menus.OrderBy(x => x.Id).ToPagedList(page, pageSize);
        }

        public menu GetById(int ID)
        {
            return db.menus.SingleOrDefault(x => x.Id == ID);
        }

        public menu ViewDetail(int iD)
        {
            return db.menus.Find(iD);
        }

        public bool Update(menu entity)
        {
            try
            {
                var Menu = db.menus.Find(entity.Id);
                Menu.name = entity.name;
                Menu.idparent = entity.idparent;
                Menu.no_ = entity.no_;
                Menu.meta = entity.meta;
                Menu.hide = entity.hide;
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
