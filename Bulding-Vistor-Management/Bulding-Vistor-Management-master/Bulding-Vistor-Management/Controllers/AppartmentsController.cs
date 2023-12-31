﻿using System;
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
    public class AppartmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: Appartments
        public ActionResult Index()
        {
            return View(db.Appartments.ToList());
        }

        // GET: Appartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }

        // GET: Appartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppartmentId,AppartmentNumber")] Appartment appartment)
        {
            if (ModelState.IsValid)
            {
                db.Appartments.Add(appartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appartment);
        }

        // GET: Appartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }

        // POST: Appartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppartmentId,AppartmentNumber")] Appartment appartment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appartment);
        }

        // GET: Appartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appartment appartment = db.Appartments.Find(id);
            if (appartment == null)
            {
                return HttpNotFound();
            }
            return View(appartment);
        }

        // POST: Appartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appartment appartment = db.Appartments.Find(id);
            db.Appartments.Remove(appartment);
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
