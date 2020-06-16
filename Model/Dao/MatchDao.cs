using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class MatchDao
    {
        LTWebDataContext db = null;
        public MatchDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(CapDau entity)
        {
            db.CapDaus.Add(entity);
            db.SaveChanges();
            return entity.ID_capdau;
        }

        public List<CapDau> ListAll()
        {
            return db.CapDaus.OrderByDescending(x=>x.ID_capdau).ToList();
        }
        public CapDau GetById(long id)
        {
            return db.CapDaus.SingleOrDefault(x => x.ID_capdau == id);
        }
        public Lich GetByIDLich(long id)
        {
            return db.Liches.SingleOrDefault(x => x.ID_lich == id);
        }
        public List<LichCapDau> ListLichThiDau(long idlich,long idcd)
        {
            return db.LichCapDaus.OrderByDescending(x => x.IDLich == idlich && x.IDCapdau == idcd).ToList();
        }

    }
}
