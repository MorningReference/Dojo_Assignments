using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            string paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id varius elit. Sed varius ipsum id accumsan convallis. Quisque sapien urna, placerat eu metus maximus, sollicitudin maximus ligula. Maecenas aliquam, nibh non accumsan placerat, leo sapien accumsan nisi, in pharetra lectus sem at velit. Phasellus leo tortor, sollicitudin nec dui sit amet, ultrices finibus nulla. Mauris vulputate risus turpis, ac ullamcorper dolor sodales eget. Praesent efficitur ac ligula ut sollicitudin. Suspendisse mollis felis eleifend dictum mattis. ";
            return View("Index", paragraph);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = { 1, 2, 3, 10, 43, 5 };
            return View("Numbers", numbers);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            List<User> users = new List<User>
            {
                new User(){FirstName = "Moose", LastName = "Phillips"},
                new User(){FirstName = "Sarah", LastName = "Snow"},
                new User(){FirstName = "Jerry", LastName = "Jord"},
                new User(){FirstName = "Rene", LastName = "Rast"},
                new User(){FirstName = "Barbarah", LastName = "Bon"}
            };
            return View("Users", users);
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            User user = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };
            return View("User", user);
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
