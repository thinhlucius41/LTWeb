using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KetQuaDao
    {
        LTWebDataContext db = null;
        public KetQuaDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(CT_CD entity)
        {
            db.CT_CD.Add(entity);
            db.SaveChanges();
            return entity.IDcapDau;
        }

        public IEnumerable<CT_CD> ListAllPaging(int page, int pageSize)
        {
            return db.CT_CD.OrderByDescending(x => x.CLB).ToPagedList(page, pageSize);
        }

        public CT_CD GetById(long id)
        {
            return db.CT_CD.SingleOrDefault(x => x.IDcapDau == id);
        }

        public CT_CD ViewDetail(long ID)
        {
            return db.CT_CD.Find(ID);
        }

        public bool Update(CT_CD entity)
        {
            try
            {
                var item = db.CT_CD.Find(entity.CLB);
                item.IDcapDau = entity.IDcapDau;
                item.IDclb = entity.IDclb;
                item.KetQua = entity.KetQua;
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
                var kq = db.CapDaus.Find(id);
                db.CapDaus.Remove(kq);
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
