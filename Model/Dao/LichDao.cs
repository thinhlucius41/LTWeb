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

        public long Insert(CapDau entity)
        {
            db.CapDaus.Add(entity);
            db.SaveChanges();
            return entity.IDcapDau;
        }

        public IEnumerable<CapDau> ListAllPaging(int page, int pageSize)
        {
            return db.CapDaus.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }

        public CapDau GetById(long id)
        {
            return db.CapDaus.SingleOrDefault(x => x.IDcapDau == id);
        }

        public CapDau ViewDetail(long ID)
        {
            return db.CapDaus.Find(ID);
        }

        public bool Update(CapDau entity)
        {
            try
            {
                var item = db.CapDaus.Find(entity.IDcapDau);
                item.NgayDau = entity.NgayDau;
                item.GioDau = entity.GioDau;
                item.DoiNha = entity.DoiNha;
                item.DoiKhach = entity.DoiKhach;
                item.MuaGiai = entity.MuaGiai;
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
                var cd = db.CapDaus.Find(id);
                db.CapDaus.Remove(cd);
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
