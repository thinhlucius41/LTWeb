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
    public class CapDausController : BaseController
    {
        private LTWebDataContext db = new LTWebDataContext();

        // GET: Admin/CapDaus
        public async Task<ActionResult> Index()
        {
            var capDaus = db.CapDaus.Include(c => c.CLB).Include(c => c.CLB1);
            return View(await capDaus.ToListAsync());
        }

        // GET: Admin/CapDaus/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapDau capDau = await db.CapDaus.FindAsync(id);
            if (capDau == null)
            {
                return HttpNotFound();
            }
            return View(capDau);
        }

        // GET: Admin/CapDaus/Create
        public ActionResult Create()
        {
            ViewBag.IDclbNha = new SelectList(db.CLBs, "IDclb", "TenClb");
            ViewBag.IDclbKhach = new SelectList(db.CLBs, "IDclb", "TenClb");
            return View();
        }

        // POST: Admin/CapDaus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_capdau,IDclbNha,IDclbKhach")] CapDau capDau)
        {
            if (ModelState.IsValid)
            {
                db.CapDaus.Add(capDau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IDclbNha = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbNha);
            ViewBag.IDclbKhach = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbKhach);
            return View(capDau);
        }

        // GET: Admin/CapDaus/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapDau capDau = await db.CapDaus.FindAsync(id);
            if (capDau == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDclbNha = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbNha);
            ViewBag.IDclbKhach = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbKhach);
            return View(capDau);
        }

        // POST: Admin/CapDaus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_capdau,IDclbNha,IDclbKhach")] CapDau capDau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(capDau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDclbNha = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbNha);
            ViewBag.IDclbKhach = new SelectList(db.CLBs, "IDclb", "TenClb", capDau.IDclbKhach);
            return View(capDau);
        }

        // GET: Admin/CapDaus/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CapDau capDau = await db.CapDaus.FindAsync(id);
            if (capDau == null)
            {
                return HttpNotFound();
            }
            return View(capDau);
        }

        // POST: Admin/CapDaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CapDau capDau = await db.CapDaus.FindAsync(id);
            db.CapDaus.Remove(capDau);
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
