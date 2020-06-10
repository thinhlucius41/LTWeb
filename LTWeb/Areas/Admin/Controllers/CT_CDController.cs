using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace LTWeb.Areas.Admin.Controllers
{
    public class CT_CDController : BaseController
    {
        LTWebDataContext db = new LTWebDataContext();

        // GET: Admin/CT_CD
        public ActionResult Index()
        {
            var cT_CD = db.CT_CD.Include(c => c.CapDau).Include(c => c.CLB);
            return View(cT_CD.ToList());
        }

        // GET: Admin/CT_CD/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_CD cT_CD = db.CT_CD.Find(id);
            if (cT_CD == null)
            {
                return HttpNotFound();
            }
            return View(cT_CD);
        }

        // GET: Admin/CT_CD/Create
        public ActionResult Create()
        {
            ViewBag.IDcapDau = new SelectList(db.CapDaus, "IDcapDau", "NgayDau");
            ViewBag.IDclb = new SelectList(db.CLBs, "IDclb", "TenClb");
            return View();
        }

        // POST: Admin/CT_CD/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDcapDau,IDclb,KetQua")] CT_CD cT_CD)
        {
            if (ModelState.IsValid)
            {
                db.CT_CD.Add(cT_CD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDcapDau = new SelectList(db.CapDaus, "IDcapDau", "NgayDau", cT_CD.IDcapDau);
            ViewBag.IDclb = new SelectList(db.CLBs, "IDclb", "TenClb", cT_CD.IDclb);
            return View(cT_CD);
        }

        // GET: Admin/CT_CD/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_CD cT_CD = db.CT_CD.Find(id);
            if (cT_CD == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDcapDau = new SelectList(db.CapDaus, "IDcapDau", "NgayDau", cT_CD.IDcapDau);
            ViewBag.IDclb = new SelectList(db.CLBs, "IDclb", "TenClb", cT_CD.IDclb);
            return View(cT_CD);
        }

        // POST: Admin/CT_CD/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDcapDau,IDclb,KetQua")] CT_CD cT_CD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_CD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDcapDau = new SelectList(db.CapDaus, "IDcapDau", "NgayDau", cT_CD.IDcapDau);
            ViewBag.IDclb = new SelectList(db.CLBs, "IDclb", "TenClb", cT_CD.IDclb);
            return View(cT_CD);
        }

        // GET: Admin/CT_CD/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_CD cT_CD = db.CT_CD.Find(id);
            if (cT_CD == null)
            {
                return HttpNotFound();
            }
            return View(cT_CD);
        }

        // POST: Admin/CT_CD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CT_CD cT_CD = db.CT_CD.Find(id);
            db.CT_CD.Remove(cT_CD);
            db.SaveChanges();
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
