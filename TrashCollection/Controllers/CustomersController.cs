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
    public class CustomersController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        public ActionResult EmployeePickUpDetails()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult EmployeePickUp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ZipCode,StreetAddress,City,State,DaysOfTheWeekPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                customer.MonthlyPayment = CalculateMonthlyUpcomingFee(customer.DaysOfTheWeekPickUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult CreateOneDayPickUp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/EmployeePickUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePickUp([Bind(Include = "Id,FirstName,LastName,ZipCode,StreetAddress,City,State,DaysOfTheWeekPickUp,PickUpDone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.PickUpDone == false)
                {
                    db.Entry(customer).State = EntityState.Modified;
                    customer.PickUpDone = true;
                    customer.CurrentlyDue += 5;
                }                    
                else
                {
                    customer.PickUpDone = false;
                }
                customer.MonthlyPayment = CalculateMonthlyUpcomingFee(customer.DaysOfTheWeekPickUp);
                db.SaveChanges();
                return RedirectToAction("EmployeePickUpDetails");
            }
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOneDayPickUp([Bind(Include = "Id,FirstName,LastName,ZipCode,StreetAddress,City,State,DaysOfTheWeekPickUp,OneDayPickUp,PickUpStartDateSuspend,PickUpEndDateSuspend")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EmployeePickUpDetails");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ZipCode,StreetAddress,City,State,DaysOfTheWeekPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                customer.MonthlyPayment = CalculateMonthlyUpcomingFee(customer.DaysOfTheWeekPickUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        public ActionResult EditDay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDay([Bind(Include = "Id,FirstName,LastName,ZipCode,StreetAddress,City,State,DaysOfTheWeekPickUp")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                customer.MonthlyPayment = CalculateMonthlyUpcomingFee(customer.DaysOfTheWeekPickUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
        public int CalculateMonthlyUpcomingFee(DayOfWeek DaysOfTheWeekPickUp)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddDays(30);
            TimeSpan ts = end - start;               
            int count = (int)Math.Floor(ts.TotalDays / 7);
            int remainder = (int)(ts.TotalDays % 7);
            int sinceLastDay = (int)(end.DayOfWeek - DaysOfTheWeekPickUp); 
            if (sinceLastDay < 0) sinceLastDay += 7; 

            if (remainder >= sinceLastDay) count++;

            return (count * 5);
        }

    }
}
