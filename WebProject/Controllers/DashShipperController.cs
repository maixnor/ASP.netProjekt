using System;
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
    public class DashShipperController : Controller
    {
        private Northwind db = new Northwind();

        // GET: DashShipper
        public ActionResult Index(int? shipper)
        {
            if (shipper == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
            orders = orders.Where(t => t.ShipVia == shipper);
            return View(orders.ToList());
        }

        // GET: DashShipper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: DashShipper/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName");
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName");
            return View();
        }

        // POST: DashShipper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: DashShipper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        // POST: DashShipper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,CustomerID,EmployeeID,OrderDate,RequiredDate,ShippedDate,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        // GET: DashShipper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: DashShipper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
