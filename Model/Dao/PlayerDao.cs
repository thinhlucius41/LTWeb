using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PlayerDao
    {
        LTWebDataContext db = null;
        public PlayerDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(CauThu entity)
        {
            db.CauThus.Add(entity);
            db.SaveChanges();
            return entity.IDcauThu;
        }

        public IEnumerable<CauThu> ListAllPaging(int page, int pageSize)
        {
            return db.CauThus.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }
        public List<CLB> ListAll()
        {
            return db.CLBs.Where(x=>x.hide== true).ToList();
        }
        public CauThu GetById(long id)
        {
            return db.CauThus.SingleOrDefault(x => x.IDcauThu == id);
        }

        public CauThu ViewDetail(long ID)
        {
            return db.CauThus.Find(ID);
        }

        public bool Update(CauThu entity)
        {
            try
            {
                var item = db.CauThus.Find(entity.IDcauThu);
                item.IDclb = entity.IDclb;
                item.TenCT = entity.TenCT;
                item.AnhCT= entity.AnhCT;
                item.ViTri = entity.ViTri;
                item.IDclb = entity.IDclb;
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
                var ct = db.CauThus.Find(id);
                db.CauThus.Remove(ct);
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
