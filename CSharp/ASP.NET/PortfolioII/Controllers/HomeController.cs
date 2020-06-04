using Microsoft.AspNetCore.Mvc;

namespace PortfolioII.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View("Projects");
        }
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View("Contact");
        }

        [HttpGet("success")]
        public RedirectToActionResult Success()
        {
            return RedirectToAction("Index");
        }

    }
}