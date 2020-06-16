using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private CRUDeliciousContext db;
        public HomeController(CRUDeliciousContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefs = db.Chefs.ToList();
            return View("Index", chefs);
        }

        [HttpGet("new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("chef/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if (ModelState.IsValid)
            {
                db.Add(newChef);
                db.SaveChanges();
                return RedirectToAction("Dishes");
            }
            return View("NewChef");
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dishes> dishes = db.Dishes.Include(d => d.Creator).ToList();
            return View("Dishes", dishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            // List<Chef> chefs = db.Chefs.ToList();
            // ViewBag.Chefs = chefs;
            IndexViewModel WMod = new IndexViewModel();
            WMod.AllChefs = db.Chefs.ToList();

            return View("NewDish", WMod);
        }

        [HttpPost("dish/create")]
        public IActionResult CreateDish(IndexViewModel newDish)
        {
            // List<Chef> chefs = db.Chefs.ToList();
            // ViewBag.Chefs = chefs;
            IndexViewModel WMod = new IndexViewModel();
            WMod.AllChefs = db.Chefs.ToList();
            if (ModelState.IsValid)
            {
                db.Add(newDish.Dish);
                db.SaveChanges();
                return RedirectToAction("Dishes");
            }
            return View("Dishes", WMod);
        }

        [HttpGet("{dishId}")]
        public IActionResult DisplayDish(int dishId)
        {
            Dishes RetrievedDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View("DisplayDish", RetrievedDish);
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dishes RetrievedDish = db.Dishes.Include(d => d.Creator).FirstOrDefault(d => d.DishId == dishId);
            return View("EditDish", RetrievedDish);
        }

        // [HttpPost("update/{dishId}")]
        // public IActionResult UpdateDish(Dishes updatedDish, int dishId)
        // {
        //     Console.WriteLine("It is updating");

        //     Dishes RetrievedDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
        // RetrievedDish.Name = updatedDish.Name;
        // RetrievedDish.Chef = updatedDish.Chef;
        // RetrievedDish.Tastiness = updatedDish.Tastiness;
        // RetrievedDish.Calories = updatedDish.Calories;
        // RetrievedDish.Description = updatedDish.Description;
        // RetrievedDish.UpdatedAt = DateTime.Now;
        //     updatedDish.DishId = RetrievedDish.DishId;
        //     db.Dishes.Update(updatedDish);
        //     db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dishes RetrievedDish = db.Dishes.SingleOrDefault(d => d.DishId == dishId);
            db.Dishes.Remove(RetrievedDish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
