using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProject;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class DashAdminController : Controller
    {
        private Northwind db = new Northwind();

        public ActionResult AsCustomer(string id)
        {
            Customer customer;
            if (ModelState.IsValid)
            {
                using (var db = new Northwind())
                {
                    customer = db.Customers.Find(id);
                }
                if (customer != null)
                {
                    //logout admin
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    // log in customer
                    FormsAuthentication.SetAuthCookie(customer.CustomerID, false);
                    Session["cid"] = customer.CustomerID;
                    return RedirectToAction("Index", "DashCustomer", new { });
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "This log in did not work");
                }
            }
            return View();
        }

        public ActionResult AsEmployee(int? id)
        {
            Employee employee;
            if (ModelState.IsValid)
            {
                using (var db = new Northwind())
                {
                    employee = db.Employees.Find(id);
                }
                if (employee != null)
                {
                    //logout admin
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    // log in employee
                    FormsAuthentication.SetAuthCookie(employee.EmployeeID.ToString(), false);
                    Session["eid"] = employee.EmployeeID;
                    return RedirectToAction("Index", "DashEmployee", new { });
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "This log in did not work");
                }
            }
            return View();
        }

        public ActionResult AsShipper(int? id)
        {
            Shipper shipper;
            if (ModelState.IsValid)
            {
                using (var db = new Northwind())
                {
                    shipper = db.Shippers.Find(id);
                }
                if (shipper != null)
                {
                    //logout admin
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    // log in shipper
                    FormsAuthentication.SetAuthCookie(shipper.ShipperID.ToString(), false);
                    Session["shid"] = shipper.ShipperID;
                    return RedirectToAction("Index", "DashShipper", new { });
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "This log in did not work");
                }
            }
            return View();
        }

        public ActionResult AsSupplier(int? id)
        {
            Supplier supplier;
            if (ModelState.IsValid)
            {
                using (var db = new Northwind())
                {
                    supplier = db.Suppliers.Find(id);
                }
                if (supplier != null)
                {
                    //logout admin
                    Session.Clear();
                    FormsAuthentication.SignOut();
                    // log in supplier
                    FormsAuthentication.SetAuthCookie(supplier.SupplierID.ToString(), false);
                    Session["suid"] = supplier.SupplierID;
                    return RedirectToAction("Index", "DashSupplier", new { });
                    //return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "This log in did not work");
                }
            }
            return View();
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: DashAdmin
        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("admin", false);
            Session["a"] = true;
            return View(db.Categories.ToList());
        }

        // GET: DashAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: DashAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: DashAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: DashAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: DashAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: DashAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
