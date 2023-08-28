using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bulding_Vistor_Management.Models;

namespace Bulding_Vistor_Management.Controllers
{
    public class RecordsController : Controller
    {
        private Entities db = new Entities();

        // GET: Records
        public ActionResult Index()
        {
            var records = db.Records.Include(r => r.Appartment).Include(r => r.Tenant).Include(r => r.Visitor);
            return View(records.ToList());
        }

        // GET: Records/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.AppartmentId = new SelectList(db.Appartments, "AppartmentId", "AppartmentNumber");
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "TenantFullnames");
            ViewBag.VisitorId = new SelectList(db.Visitors, "VisitorId", "Fullnames");
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,VisitorId,Date,Time,TenantId,AppartmentId")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(record);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppartmentId = new SelectList(db.Appartments, "AppartmentId", "AppartmentNumber", record.AppartmentId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "TenantFullnames", record.TenantId);
            ViewBag.VisitorId = new SelectList(db.Visitors, "VisitorId", "Fullnames", record.VisitorId);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppartmentId = new SelectList(db.Appartments, "AppartmentId", "AppartmentNumber", record.AppartmentId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "TenantFullnames", record.TenantId);
            ViewBag.VisitorId = new SelectList(db.Visitors, "VisitorId", "Fullnames", record.VisitorId);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,VisitorId,Date,Time,TenantId,AppartmentId")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppartmentId = new SelectList(db.Appartments, "AppartmentId", "AppartmentNumber", record.AppartmentId);
            ViewBag.TenantId = new SelectList(db.Tenants, "TenantId", "TenantFullnames", record.TenantId);
            ViewBag.VisitorId = new SelectList(db.Visitors, "VisitorId", "Fullnames", record.VisitorId);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Records.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Records.Find(id);
            db.Records.Remove(record);
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
