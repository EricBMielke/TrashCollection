﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class EmployeesController : Controller
    {
       

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
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
            return View(employee);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ZipCode,DaysOfTheWeekToPickUp,CustomersToPickUpDuringWeek,CustomersToPickUpToday")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                employee.CustomersToPickUpDuringWeek = FindCustomersForEmployeeByZip(employee.ZipCode);
                employee.CustomersToPickUpToday = FindCustomersForEmployeeByDay(employee.DaysOfTheWeekToPickUp, employee.ZipCode);
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ZipCode,DaysOfTheWeekToPickUp,CustomersToPickUpDuringWeeks,CustomersToPickUpToday")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                employee.CustomersToPickUpDuringWeek = FindCustomersForEmployeeByZip(employee.ZipCode);
                employee.CustomersToPickUpToday = FindCustomersForEmployeeByDay(employee.DaysOfTheWeekToPickUp, employee.ZipCode);
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
        public string FindCustomersForEmployeeByZip(string employeeZip)
        {
            List<string> customersInZipToday = new List<string>();

            var customers = db.Customers; 
            foreach (var customer in customers) 
            {
                if (customer.ZipCode == employeeZip)
                {
                    customersInZipToday.Add(customer.FirstName + " " + customer.LastName + " at " + customer.StreetAddress); 
                }
            }
            var stringCustomersToday = String.Join(", ", customersInZipToday.ToArray());
            return stringCustomersToday;
        }
        public List<string> CreateListOfCustomersToday(DayOfWeek employeeDay, string employeeZip)
        {
            List<string> customersInRouteToday = new List<string>();
            var customers = db.Customers;
            foreach (var customer in customers)
            {
                var DayOfWeekString = customer.DaysOfTheWeekPickUp.ToString();
                var employeeDayString = employeeDay.ToString();
                if (DayOfWeekString == employeeDayString && customer.ZipCode == employeeZip)
                {
                    customersInRouteToday.Add(customer.FirstName);
                }
            }
            return customersInRouteToday;

        }
        public string FindCustomersForEmployeeByDay(DayOfWeek employeeDay, string employeeZip)
        {
            List<string> customersInDay = new List<string>();
            var customers = db.Customers;
            foreach (var customer in customers)
            {
                var DayOfWeekString = customer.DaysOfTheWeekPickUp.ToString();
                var employeeDayString = employeeDay.ToString();
                if (DayOfWeekString == employeeDayString && customer.ZipCode == employeeZip)
                {
                    customersInDay.Add(customer.FirstName + " " + customer.LastName + " at " + customer.StreetAddress);
                }
            }
            var stringCustomersToday = String.Join(", ", customersInDay.ToArray());
            return stringCustomersToday;
        }

    }
}
