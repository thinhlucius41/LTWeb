using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ClubsDao
    {
        LTWebDataContext db = null;
        public ClubsDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(CLB entity)
        {
            db.CLBs.Add(entity);
            db.SaveChanges();
            return entity.IDclb;
        }

        public IEnumerable<CLB> ListAllPaging(int page, int pageSize)
        {
            return db.CLBs.OrderByDescending(x=>x.dateBegin).ToPagedList(page, pageSize);
        }
        public List<GiaiDau> ListAll()
        {
            return db.GiaiDaus.Where(x=>x.hide== true).ToList();
        }

        public CLB GetById(long id)
        {
            return db.CLBs.SingleOrDefault(x => x.IDclb == id);
        }

        public CLB ViewDetail(long ID)
        {
            return db.CLBs.Find(ID);
        }

        public bool Update(CLB entity)
        {
            try
            {
                var item = db.CLBs.Find(entity.IDclb);
                item.IDGiai = entity.IDGiai;
                item.TenClb = entity.TenClb;
                item.Logo = entity.Logo;
                item.NguoiSangLap = entity.NguoiSangLap;
                item.NamThanhLap = entity.NamThanhLap;
                item.ViTri = entity.ViTri;
                item.GioiThieu = entity.GioiThieu;
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
                var i = db.CLBs.Find(id);
                db.CLBs.Remove(i);
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
