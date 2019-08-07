using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
    }
    // POST: Customer/Create
    [HttpPost]
    public ActionResult CreateCustomer(Customer customer)
    {
        try
        {
            db.Customer.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
}