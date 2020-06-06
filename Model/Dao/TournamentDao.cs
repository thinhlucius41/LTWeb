using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TournamentDao
    {
        LTWebDataContext db = null;
        public TournamentDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(GiaiDau entity)
        {
            db.GiaiDaus.Add(entity);
            db.SaveChanges();
            return entity.IDGiai;
        }

        public IEnumerable<GiaiDau> ListAllPaging( int page, int pageSize)
        {
            return db.GiaiDaus.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }

        public GiaiDau GetById(long id)
        {
            return db.GiaiDaus.SingleOrDefault(x => x.IDGiai == id);
        }

        public GiaiDau ViewDetail(long ID)
        {
            return db.GiaiDaus.Find(ID);
        }

        public bool Update(GiaiDau entity)
        {
            try
            {
                var giai = db.GiaiDaus.Find(entity.IDGiai);
                giai.TenGD = entity.TenGD;
                giai.NgayBatDau = entity.NgayBatDau;
                giai.NgayKetThuc = entity.NgayKetThuc;
                giai.meta = entity.meta;
                giai.hide = entity.hide;
                giai.order = entity.order;               
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
                var giaidau = db.GiaiDaus.Find(id);
                db.GiaiDaus.Remove(giaidau);
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
