﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProject;

namespace WebProject.Controllers
{
    [Authorize]
    public class TerritoriesController : Controller
    {
        private Northwind db = new Northwind();

        // GET: Territories
        public ActionResult Index(int? region)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            var territories = db.Territories.Include(t => t.Region);
            if (region != null)
                territories = territories.Where(t => t.RegionID == region);
            return View(territories.ToList());
        }

        // GET: Territories/Details/5
        public ActionResult Details(string id)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territories.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return View(territory);
        }

        // GET: Territories/Create
        public ActionResult Create()
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionDescription");
            return View();
        }

        // POST: Territories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerritoryID,TerritoryDescription,RegionID")] Territory territory)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (ModelState.IsValid)
            {
                db.Territories.Add(territory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionDescription", territory.RegionID);
            return View(territory);
        }

        // GET: Territories/Edit/5
        public ActionResult Edit(string id)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territories.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionDescription", territory.RegionID);
            return View(territory);
        }

        // POST: Territories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerritoryID,TerritoryDescription,RegionID")] Territory territory)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (ModelState.IsValid)
            {
                db.Entry(territory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionDescription", territory.RegionID);
            return View(territory);
        }

        // GET: Territories/Delete/5
        public ActionResult Delete(string id)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Territory territory = db.Territories.Find(id);
            if (territory == null)
            {
                return HttpNotFound();
            }
            return View(territory);
        }

        // POST: Territories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            Territory territory = db.Territories.Find(id);
            db.Territories.Remove(territory);
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
