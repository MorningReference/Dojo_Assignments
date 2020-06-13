using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    public class HomeController : Controller
    {
        private BankAccountContext db;
        public HomeController(BankAccountContext context)
        {
            db = context;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            // User user = new User();
            return View("Register");
        }

        [HttpPost("process/register")]
        public IActionResult ProcessRegister(User newUser)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                db.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("User", newUser.UserId);
                return RedirectToAction("BankAccount", new { userId = newUser.UserId });
            }
            return View("Register");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("process/login")]
        public IActionResult ProcessLogin(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {
                var userInDb = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LoginPassword);

                if (result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("User", userInDb.UserId);
                return RedirectToAction("BankAccount", new { userId = userInDb.UserId });
            }
            return View("Login");
        }

        [HttpGet("account/{userId}")]
        public IActionResult BankAccount(int userId)
        {
            int? currentUserId = HttpContext.Session.GetInt32("User");
            var currentUser = db.Users.FirstOrDefault(u => u.UserId == currentUserId);
            if (db.Users.Any(u => u.UserId == currentUserId))
            {
                if (currentUserId != userId)
                {
                    return RedirectToAction("BankAccount", new { userId = currentUserId });
                }
                BankAccountViewModel WMod = new BankAccountViewModel();
                WMod.CurrentUser = db.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == currentUserId);
                WMod.AllUserTransactions = db.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == currentUserId).Transactions.OrderByDescending(t => t.CreatedAt).ToList();
                // if (currentUser.Transactions != null)
                // {
                // WMod.Transaction = db.Users.FirstOrDefault(u => u.UserId == currentUserId).Transactions;
                // }
                // else
                // {
                //     WMod.AllUserTransactions = new List<Transaction>();
                // }
                return View("BankAccount", WMod);
            }

            return RedirectToAction("Login");
        }

        [HttpPost("process")]
        public IActionResult ProcessChange(BankAccountViewModel changeOnAccount)
        {
            int? currentUserId = HttpContext.Session.GetInt32("User");

            User currentUser = db.Users.FirstOrDefault(u => u.UserId == currentUserId);

            // BankAccountViewModel WMod = new BankAccountViewModel();
            // WMod.CurrentUser = db.Users.FirstOrDefault(u => u.UserId == currentUserId);

            // if (currentUser.Transactions != null)
            // {
            //     WMod.AllUserTransactions = db.Users
            //         .FirstOrDefault(u => u.UserId == currentUserId)
            //         .Transactions.OrderByDescending(t => t.CreatedAt)
            //         .ToList();
            // }
            // else
            // {
            //     WMod.AllUserTransactions = new List<Transaction>();
            // }

            if (ModelState.IsValid)
            {
                if (changeOnAccount.Transaction.Amount > 0 && currentUser.Balance < changeOnAccount.Transaction.Amount)
                {
                    ModelState.AddModelError("Amount", "Your balance must be greater than what you are withdrawing!");
                }
                changeOnAccount.Transaction.UserId = (int)currentUserId;
                currentUser.Balance += changeOnAccount.Transaction.Amount;
                db.Transactions.Update(changeOnAccount.Transaction);
                db.Users.Update(currentUser);
                db.SaveChanges();
                return RedirectToAction("BankAccount", new { userId = currentUserId });
            }
            return View("BankAccount", changeOnAccount);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
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
