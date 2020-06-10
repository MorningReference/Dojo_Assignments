using System.Linq;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndRegistration.Controllers
{
    public class UserController : Controller
    {
        private LoginAndRegistrationContext db;
        public UserController(LoginAndRegistrationContext context)
        {
            db = context;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            User user = new User();
            return View("Register", user);
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
                return RedirectToAction("Success");
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
                var userInDb = db.Users.FirstOrDefault(u => u.Email == loginUser.Email);

                if (userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.Password);

                if (result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email or Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("User", userInDb.UserId);
                return RedirectToAction("Success");
            }
            return View("Login");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            var userId = HttpContext.Session.GetInt32("User");
            if (db.Users.Any(u => u.UserId == userId))
            {
                return View("Success");
            }
            return RedirectToAction("Login");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}