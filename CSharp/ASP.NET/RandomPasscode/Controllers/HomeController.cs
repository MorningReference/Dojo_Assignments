using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using RandomPasscode;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string password = RandomPasscode.PasscodeGenerator.RandomPassword(14);
            HttpContext.Session.SetInt32("Count", 1);
            ViewBag.Password = password;
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View("Index");
        }

        [HttpGet("generate")]
        public IActionResult Generate()
        {
            int count = (int)HttpContext.Session.GetInt32("Count") + 1;
            HttpContext.Session.SetInt32("Count", count);
            string password = RandomPasscode.PasscodeGenerator.RandomPassword(14);
            ViewBag.Password = password;
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            return View("Index");
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
