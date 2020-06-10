using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

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
            List<Dishes> dishes = db.Dishes
                .OrderByDescending(d => d.CreatedAt)
                .Take(5)
                .ToList();
            return View("Index", dishes);
        }

        [HttpGet("new")]
        public IActionResult NewDish()
        {
            return View("NewDish");
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dishes newDish)
        {
            db.Add(newDish);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            Dishes RetrievedDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            return View("EditDish", RetrievedDish);
        }

        [HttpPost("update/{dishId}")]
        public IActionResult UpdateDish(Dishes updatedDish, int dishId)
        {
            Console.WriteLine("It is updating");
            Dishes RetrievedDish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            RetrievedDish.Name = updatedDish.Name;
            RetrievedDish.Chef = updatedDish.Chef;
            RetrievedDish.Tastiness = updatedDish.Tastiness;
            RetrievedDish.Calories = updatedDish.Calories;
            RetrievedDish.Description = updatedDish.Description;
            RetrievedDish.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
