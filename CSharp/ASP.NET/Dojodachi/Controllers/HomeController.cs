using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            Dojodachi dojodachi = new Dojodachi();
            dojodachi.Happiness = 20;
            dojodachi.Fullness = 20;
            dojodachi.Energy = 50;
            dojodachi.Meal = 3;
            dojodachi.Message = "Welcome to Dojodachi!";
            dojodachi.Image = "/images/kuchipatchi.jpg";
            HttpContext.Session.SetObjectAsJson("Dojodachi", dojodachi);
            return View(dojodachi);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            Random like = new Random();
            Random randFull = new Random();
            int full = randFull.Next(5, 11);

            if (retrieve.Meal <= 0)
            {
                retrieve.Message = "You don't have enough meals to feed your Dojodachi! Put your Dojodachi to work to get more meals!";
            }
            else if (like.Next(5) == 1)
            {
                retrieve.Meal -= 1;
                retrieve.Message = "Your Dojodachi did not like the meal! Meal -1";
                retrieve.Image = "/images/kuchipatchi_mad.jpg";
            }
            else
            {
                retrieve.Meal -= 1;
                retrieve.Fullness += full;
                retrieve.Message = $"You fed your Dojodachi! Meal -1, Fullness + {full}";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
            }

            if (retrieve.Happiness >= 100 && retrieve.Energy >= 100 && retrieve.Fullness >= 100)
            {
                retrieve.Message = "Congratulations! You won!";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Win");
            }
            else if (retrieve.Fullness <= 0 || retrieve.Happiness <= 0)
            {
                retrieve.Message = "Your Dojodachi has passed away...";
                retrieve.Image = "/images/kuchipatchi_sad.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Lose");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
            return View("Index", retrieve);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Random like = new Random();
            Random randHappy = new Random();
            int happy = randHappy.Next(5, 11);
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");

            if (retrieve.Energy <= 0)
            {
                retrieve.Message = "Your Dojodachi does not have any more energy to play! Put your Dojodachi to sleep to recover its energy!";
            }
            else if (like.Next(5) == 1)
            {
                retrieve.Energy -= 5;
                retrieve.Message = "Your Dojodachi did not like the playtime! Energy -5";
                retrieve.Image = "/images/kuchipatchi_mad.jpg";
            }
            else
            {
                retrieve.Energy -= 5;
                retrieve.Happiness += happy;
                retrieve.Message = $"You played with your Dojodachi! Happiness +{happy}, Energy -5";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
            }

            if (retrieve.Happiness >= 100 && retrieve.Energy >= 100 && retrieve.Fullness >= 100)
            {
                retrieve.Message = "Congratulations! You won!";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Win");
            }
            else if (retrieve.Fullness <= 0 || retrieve.Happiness <= 0)
            {
                retrieve.Message = "Your Dojodachi has passed away...";
                retrieve.Image = "/images/kuchipatchi_sad.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Lose");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
            return View("Index", retrieve);
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Random randMeal = new Random();
            int meal = randMeal.Next(1, 4);
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            if (retrieve.Energy <= 0)
            {
                retrieve.Message = "Your Dojodachi does not have any more energy to play! Put your Dojodachi to sleep to recover its energy!";
            }
            else
            {
                retrieve.Energy -= 5;
                retrieve.Meal += meal;
                retrieve.Message = $"You put your Dojodachi to work! Meal +{meal}, Energy -5";
            }


            if (retrieve.Happiness >= 100 && retrieve.Energy >= 100 && retrieve.Fullness >= 100)
            {
                retrieve.Message = "Congratulations! You won!";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Win");
            }
            else if (retrieve.Fullness <= 0 || retrieve.Happiness <= 0)
            {
                retrieve.Message = "Your Dojodachi has passed away...";
                retrieve.Image = "/images/kuchipatchi_sad.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Lose");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
            return View("Index", retrieve);
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            retrieve.Energy += 15;
            retrieve.Fullness -= 5;
            retrieve.Happiness -= 5;
            retrieve.Message = "Your Dojodachi took a nap! Energy +15, Happiness -5, Fullness -5";

            if (retrieve.Happiness >= 100 && retrieve.Energy >= 100 && retrieve.Fullness >= 100)
            {
                retrieve.Message = "Congratulations! You won!";
                retrieve.Image = "/images/kuchipatchi_happy.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Win");
            }
            else if (retrieve.Fullness <= 0 || retrieve.Happiness <= 0)
            {
                retrieve.Message = "Your Dojodachi has passed away...";
                retrieve.Image = "/images/kuchipatchi_sad.jpg";
                HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
                return RedirectToAction("Lose");
            }
            HttpContext.Session.SetObjectAsJson("Dojodachi", retrieve);
            return View("Index", retrieve);
        }

        [HttpGet("win")]
        public IActionResult Win()
        {
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            return View("Win", retrieve);
        }

        [HttpGet("lose")]
        public IActionResult Lose()
        {
            Dojodachi retrieve = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
            return View("Lose", retrieve);
        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
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
