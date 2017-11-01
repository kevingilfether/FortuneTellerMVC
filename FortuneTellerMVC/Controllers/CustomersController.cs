using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC.Models;

namespace FortuneTellerMVC.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities db = new FortuneTellerMVCEntities();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
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

            ViewBag.BirthMonth = customer.BirthMonth;

            if (customer.Age % 2 == 0)
            {
                ViewBag.YearsToRetire = 14;
            }
            else
            {
                //highest 'int' type available, for great fun.
                ViewBag.YearsToRetire = 2147483647;
            }

            if (customer.NumberOfSiblings == 0)
            {
                ViewBag.VacationHome = "nowhere special, just Cabo San Lucas";
            }
            else if (customer.NumberOfSiblings == 1)
            {
                ViewBag.VacationHome = "in a Lake Erie undersea palace";
            }
            else if (customer.NumberOfSiblings == 2)
            {
                ViewBag.VacationHome = "on scenic the Moon";
            }
            else if (customer.NumberOfSiblings == 3)
            {
                ViewBag.VacationHome = "of a really big bouncy house";
            }
            else if (customer.NumberOfSiblings > 3)
            {
                ViewBag.VacationHome = "near Sting's house, wherever that is";
            }
            else
            {
                ViewBag.VacationHome = "on a rapidly melting arctic glacier";
            }

            //
            if (customer.FavoriteColor.ToLower() == "r" || customer.FavoriteColor.ToLower() == "red")
            {
                ViewBag.Transit = "rocket boots";
            }

            else if (customer.FavoriteColor.ToLower() == "o" || customer.FavoriteColor.ToLower() == "orange")
            {
                ViewBag.Transit = "a sweet Caddy";
            }

            else if (customer.FavoriteColor.ToLower() == "y" || customer.FavoriteColor.ToLower() == "yellow")
            {
                ViewBag.Transit = "some European luxury car";
            }

            else if (customer.FavoriteColor.ToLower() == "g" || customer.FavoriteColor.ToLower() == "green")
            {
                ViewBag.Transit = "a hanglider";
            }

            else if (customer.FavoriteColor.ToLower() == "b" || customer.FavoriteColor.ToLower() == "blue")
            {
                ViewBag.Transit = "a flock of cats conveying you like some baron";
            }

            else if (customer.FavoriteColor.ToLower() == "i" || customer.FavoriteColor.ToLower() == "indigo")
            {
                ViewBag.Transit = "Santa's sleigh";
            }

            else if (customer.FavoriteColor.ToLower() == "v" || customer.FavoriteColor.ToLower() == "violet")
            {
                ViewBag.Transit = "Chuck D's Oldsmobile 88";
            }

            else
            {
                ViewBag.Transit = "some beat up old Chuck Taylor All Stars";
            }

            //
            int iBirthMonth = 0;
            if (customer.BirthMonth.ToLower() == "january" || customer.BirthMonth.ToLower() == "jan")
                iBirthMonth = 1;
            if (customer.BirthMonth.ToLower() == "february" || customer.BirthMonth.ToLower() == "feb")
                iBirthMonth = 2;
            if (customer.BirthMonth.ToLower() == "march" || customer.BirthMonth.ToLower() == "mar")
                iBirthMonth = 3;
            if (customer.BirthMonth.ToLower() == "april" || customer.BirthMonth.ToLower() == "apr")
                iBirthMonth = 4;
            if (customer.BirthMonth.ToLower() == "may" || customer.BirthMonth.ToLower() == "may")
                iBirthMonth = 5;
            if (customer.BirthMonth.ToLower() == "june" || customer.BirthMonth.ToLower() == "jun")
                iBirthMonth = 6;
            if (customer.BirthMonth.ToLower() == "july" || customer.BirthMonth.ToLower() == "jul")
                iBirthMonth = 7;
            if (customer.BirthMonth.ToLower() == "august" || customer.BirthMonth.ToLower() == "aug")
                iBirthMonth = 8;
            if (customer.BirthMonth.ToLower() == "september" || customer.BirthMonth.ToLower() == "sep")
                iBirthMonth = 9;
            if (customer.BirthMonth.ToLower() == "october" || customer.BirthMonth.ToLower() == "oct")
                iBirthMonth = 10;
            if (customer.BirthMonth.ToLower() == "november" || customer.BirthMonth.ToLower() == "nov")
                iBirthMonth = 11;
            if (customer.BirthMonth.ToLower() == "december" || customer.BirthMonth.ToLower() == "dec")
                iBirthMonth = 12;

            if (iBirthMonth >= 1 && iBirthMonth < 5)
            {
                ViewBag.MoneyBank = 100000.00;
            }

            else if (iBirthMonth >= 5 && iBirthMonth < 9)
            {
                ViewBag.MoneyBank = 200000.00;
            }

            else if (iBirthMonth >= 9 && iBirthMonth < 13)
            {
                ViewBag.MoneyBank = 300000.00;
            }

            else
            {
                ViewBag.MoneyBank = 0.00;
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
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
    }
}
