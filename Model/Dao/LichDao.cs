using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LichDao
    {
        LTWebDataContext db = null;
        public LichDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(Lich entity)
        {
            db.Liches.Add(entity);
            db.SaveChanges();
            return entity.ID_lich;
        }

        public IEnumerable<Lich> ListAllPaging(int page, int pageSize)
        {
            return db.Liches.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }
        public List<CLB> ListAll()
        {
            return db.CLBs.Where(x=>x.hide== true).ToList();
        }
        public Lich GetById(long id)
        {
            return db.Liches.SingleOrDefault(x => x.ID_lich == id);
        }

        public Lich ViewDetail(long ID)
        {
            return db.Liches.Find(ID);
        }

        public bool Update(Lich entity)
        {
            try
            {
                var item = db.Liches.Find(entity.ID_lich);
                item.NgayDau = entity.NgayDau;
                item.GioDau = entity.GioDau;
                item.meta = entity.meta;
                item.hide = entity.hide;
                item.order = entity.order;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var cd = db.Liches.Find(id);
                db.Liches.Remove(cd);
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
