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
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
            if (Session["a"] == null) return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
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
