using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace LTWeb.Areas.Admin.Controllers
{
    public class LichCapDausController : BaseController
    {
        private LTWebDataContext db = new LTWebDataContext();

        // GET: Admin/LichCapDaus
        public async Task<ActionResult> Index()
        {
            var lichCapDaus = db.LichCapDaus.Include(l => l.CapDau).Include(l => l.Lich);
            return View(await lichCapDaus.ToListAsync());
        }

        // GET: Admin/LichCapDaus/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichCapDau lichCapDau = await db.LichCapDaus.FindAsync(id);
            if (lichCapDau == null)
            {
                return HttpNotFound();
            }
            return View(lichCapDau);
        }

        // GET: Admin/LichCapDaus/Create
        public ActionResult Create()
        {
            ViewBag.IDCapdau = new SelectList(db.CapDaus, "ID_capdau", "ID_capdau");
            ViewBag.IDLich = new SelectList(db.Liches, "ID_lich", "NgayDau");
            return View();
        }

        // POST: Admin/LichCapDaus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDCapdau,IDLich,KetQua")] LichCapDau lichCapDau)
        {
            if (ModelState.IsValid)
            {
                db.LichCapDaus.Add(lichCapDau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDCapdau = new SelectList(db.CapDaus, "ID_capdau", "ID_capdau", lichCapDau.IDCapdau);
            ViewBag.IDLich = new SelectList(db.Liches, "ID_lich", "NgayDau", lichCapDau.IDLich);
            return View(lichCapDau);
        }

        // GET: Admin/LichCapDaus/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichCapDau lichCapDau = await db.LichCapDaus.FindAsync(id);
            if (lichCapDau == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCapdau = new SelectList(db.CapDaus, "ID_capdau", "ID_capdau", lichCapDau.IDCapdau);
            ViewBag.IDLich = new SelectList(db.Liches, "ID_lich", "NgayDau", lichCapDau.IDLich);
            return View(lichCapDau);
        }

        // POST: Admin/LichCapDaus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDCapdau,IDLich,KetQua")] LichCapDau lichCapDau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichCapDau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDCapdau = new SelectList(db.CapDaus, "ID_capdau", "ID_capdau", lichCapDau.IDCapdau);
            ViewBag.IDLich = new SelectList(db.Liches, "ID_lich", "NgayDau", lichCapDau.IDLich);
            return View(lichCapDau);
        }

        // GET: Admin/LichCapDaus/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichCapDau lichCapDau = await db.LichCapDaus.FindAsync(id);
            if (lichCapDau == null)
            {
                return HttpNotFound();
            }
            return View(lichCapDau);
        }

        // POST: Admin/LichCapDaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            LichCapDau lichCapDau = await db.LichCapDaus.FindAsync(id);
            db.LichCapDaus.Remove(lichCapDau);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
