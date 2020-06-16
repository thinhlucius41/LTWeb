using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class NewsDao
    {
        LTWebDataContext db = null;
        public NewsDao()
        {
            db = new LTWebDataContext();
        }

        public long Insert(News entity)
        {
            db.News.Add(entity);
            db.SaveChanges();
            return entity.IDnews;
        }

        public IEnumerable<News> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<News> model = db.News;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TieuDe.Contains(searchString));
            }

            return model.OrderByDescending(x => x.dateBegin).ToPagedList(page, pageSize);
        }
        public IEnumerable<News> ListAllPageNews(int page, int pageSize)
        {
            return db.News.OrderByDescending(x => x.IDnews).ToPagedList(page, pageSize);
        }
        public News GetById(long id)
        {
            return db.News.SingleOrDefault(x => x.IDnews == id);
        }

        public News ViewDetail(long ID)
        {
            return db.News.Find(ID);
        }

        public bool Update(News entity)
        {
            try
            {
                var tin = db.News.Find(entity.IDnews);
                tin.TieuDe = entity.TieuDe;
                tin.Hinh = entity.Hinh;
                tin.NoiDung = entity.NoiDung;       
                tin.meta = entity.meta;
                tin.hide = entity.hide;
                tin.order = entity.order;               
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
                var news = db.News.Find(id);
                db.News.Remove(news);
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
