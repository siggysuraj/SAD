using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar(Product products)
        {
            ProductDatabaseContext db = new ProductDatabaseContext();
            if (ModelState.IsValid)
            {

                db.Product.Add(products);
                db.SaveChanges();
                return RedirectToAction("CarList");

            }
            return View(products);
        }
        [HttpGet]
        public IActionResult CheckInventory()
        {

            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult CheckInventory(Product pro)
        {
            ProductDatabaseContext db = new ProductDatabaseContext();
            string output = "";
            string output2 = "";
            string output3 = "";

            var log = from p in db.Product.Where(p => p.Brand.Equals(pro.Brand) && p.Model.Equals(pro.Model))
                      select new
                      {
                          Brand = p.Brand,
                          Model=p.Model,
                          Qty = p.Qty
                      };
            foreach (var cr in log)
            {
                output += cr.Brand;
                output2 += cr.Qty;
                output3 += cr.Model;
            }
            ViewBag.Brand = output;
            ViewBag.Qty = output2;
            ViewBag.Model = output3;
            return View();
        }
        public IActionResult CarList()
        {
            ProductDatabaseContext db = new ProductDatabaseContext();
           
            var result = from p in db.Product select p;
            return View(result);
        }
        [HttpGet]
        public IActionResult Booked()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Booked(Booked bok)
        {
            ProductDatabaseContext db = new ProductDatabaseContext();
            if (ModelState.IsValid)
            {

                db.Booked.Add(bok);
                db.SaveChanges();
               
            }

            if (db.Booked != null)
            {
                var log = (from p in db.Product.Where(p => p.Brand.Equals(bok.Brand) && p.Model.Equals(bok.Model)) select p.Qty).FirstOrDefault() - bok.Qty;
                    Product log1 = (from p in db.Product.Where(p => p.Brand.Equals(bok.Brand) && p.Model.Equals(bok.Model)) select p).FirstOrDefault();
                //if (log < 0)
                //{
                //    log = null;
                //}
                    log1.Qty = log;
                    db.Entry(log1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();


                return RedirectToAction("BookedCarList");
            }
            return View(bok);
        }
        public IActionResult BookedCarList()
        {
            ProductDatabaseContext db = new ProductDatabaseContext();

            var result = from p in db.Booked select p;
            return View(result);
        }
        public IActionResult IncomeStatement()
        {
            ProductDatabaseContext db = new ProductDatabaseContext();
            var log = from b in db.Booked select b;
            double income = (from b in db.Booked select b.Rate).Sum();
            ViewBag.income = income;

            return View(log);
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
