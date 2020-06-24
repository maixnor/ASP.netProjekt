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
    public class OrderDetailController : Controller
    {
        private Northwind db = new Northwind();

        // GET: OrderDetail
        public ActionResult Index(int? product, int? order)
        {
            var order_Details = db.Order_Details.Include(o => o.Order).Include(o => o.Product);
            if (product != null)
                order_Details = order_Details.Where(t => t.ProductID == product);
            if (order != null)
                order_Details = order_Details.Where(t => t.OrderID == order);
            return View(order_Details.ToList());
        }

        // GET: OrderDetail/Details/5
        public ActionResult Details(int? order, int? product)
        {
            if (product == null || order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Details.Find(order, product);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // GET: OrderDetail/Create
        public ActionResult Create()
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,ProductID,UnitPrice,Quantity,Discount")] Order_Detail order_Detail)
        {
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Detail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order_Detail.ProductID);
            return View(order_Detail);
        }

        // GET: OrderDetail/Edit/5
        public ActionResult Edit(int? order, int? product)
        {
            if (product == null || order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["cid"] != null)
            {
                if (db.Orders.Find(order).CustomerID == (string)Session["cid"]) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            else
            {
                if (Session["a"] == null && Session["eid"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }
            Order_Detail order_Detail = db.Order_Details.Find(order, product);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Detail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order_Detail.ProductID);
            return View(order_Detail);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,ProductID,UnitPrice,Quantity,Discount")] Order_Detail order_Detail)
        {
            if (Session["a"] == null && Session["eid"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (ModelState.IsValid)
            {
                db.Entry(order_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "CustomerID", order_Detail.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", order_Detail.ProductID);
            return View(order_Detail);
        }

        // GET: OrderDetail/Delete/5
        public ActionResult Delete(int? order, int? product)
        {
            if (Session["a"] == null && Session["eid"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            if (product == null || order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = db.Order_Details.Find(order, product);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? order, int? product)
        {
            if (Session["a"] == null && Session["eid"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            Order_Detail order_Detail = db.Order_Details.Find(order, product);
            db.Order_Details.Remove(order_Detail);
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
