using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            DayOfWeek currentDay = DateTime.Today.DayOfWeek;
            string userId = User.Identity.GetUserId();
            Employee currentEmployee = db.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            List<Customer> sameZipCustomer = db.Customers.Where(e => e.zipcode == currentEmployee.zipcode).ToList();
            List<Customer> sameDayZipcode = sameZipCustomer.Where(e => e.pickupDay == currentDay.ToString()).ToList();
            return View("Index", sameDayZipcode);
        }

        [HttpPost]
        public ActionResult Filter(string FilterDayOfWeek)
        {
            string userid = User.Identity.GetUserId();
            var currentEmployee = db.Employees.Where(e => e.ApplicationId == userid).FirstOrDefault();
            var customer = db.Customers.Where(c => c.zipcode == currentEmployee.zipcode).Where(c => c.pickupDay == FilterDayOfWeek.ToString()).ToList();
            return View(customer);
        }

        public ActionResult DaySelector(string day)
        {
            string userId = User.Identity.GetUserId();
            Employee employeeInDb = db.Employees.Where(e => e.ApplicationId == userId).SingleOrDefault();
            List<Customer> customersInZip = db.Customers.Where(c => c.zipcode == employeeInDb.zipcode).ToList();
            List<Customer> customersInZipOnDay = customersInZip.Where(c => c.pickupDay == day).ToList();
            return View("DaySelector", customersInZipOnDay);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View("Details", employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,lastName,zipcode,ApplicationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                employee.ApplicationId = userId;
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,lastName,zipcode,ApplicationId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
