using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingPlannerContext db;
        public WeddingController(WeddingPlannerContext context)
        {
            db = context;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            User loggedUser = db.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("User"));
            if (db.Users.Any(u => u.UserId == HttpContext.Session.GetInt32("User")))
            {
                DashboardViewModel wrapper = new DashboardViewModel();
                wrapper.LoggedUser = loggedUser;
                wrapper.AllWeddings = db.Weddings
                    .Include(w => w.RSVP)
                    .ThenInclude(r => r.User)
                    .ToList();

                // foreach (Wedding wedding in wrapper.AllWeddings)
                // {
                //     if (wedding.Date <= DateTime.Now)
                //     {
                // db.Weddings.Remove(wedding);
                db.Weddings.RemoveRange(db.Weddings.Where(w => w.Date >= DateTime.Now));
                db.SaveChanges();
                //     }
                // }
                return View("Dashboard", wrapper);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpGet("wedding/{weddingId}")]
        public IActionResult WeddingDetails(int weddingId)
        {
            var RetrievedWedding = db.Weddings
                .Include(w => w.RSVP)
                .ThenInclude(r => r.User)
                .FirstOrDefault(w => w.WeddingId == weddingId);
            return View("WeddingDetails", RetrievedWedding);
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View("NewWedding");
        }

        [HttpPost("wedding/create")]
        public IActionResult CreateWedding(Wedding newWedding)
        {
            var creator = db.Users
                .Include(u => u.RSVP)
                .ThenInclude(r => r.Wedding)
                .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("User"));
            newWedding.Creator = creator;

            creator.RSVP.Add(new RSVP
            {
                User = creator,
                Wedding = newWedding
            });

            db.Add(newWedding);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/{weddingId}/rsvp")]
        public IActionResult RSVP(int weddingId)
        {
            var RetrievedUser = db.Users
                .Include(u => u.RSVP)
                .ThenInclude(r => r.Wedding)
                .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("User"));
            var RetrievedWedding = db.Weddings
                .FirstOrDefault(w => w.WeddingId == weddingId);

            RetrievedUser.RSVP.Add(new RSVP
            {
                User = RetrievedUser,
                Wedding = RetrievedWedding
            });
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/{weddingId}/unrsvp")]
        public IActionResult UnRSVP(int weddingId)
        {
            var RetrievedRSVP = db.RSVPs.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == HttpContext.Session.GetInt32("User"));
            db.RSVPs.Remove(RetrievedRSVP);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/{weddingId}/delete")]
        public IActionResult Delete(int weddingId)
        {
            var RetrievedWedding = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            db.Weddings.Remove(RetrievedWedding);
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}