using DojoSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            Survey survey = new Survey();
            return View("Index", survey);
        }
        [HttpPost("result")]
        public IActionResult Result(Survey survey)
        {
            if (ModelState.IsValid)
            {
                return View("Result", survey);
            }
            else
            {
                return View("Index", survey);
            }
        }
    }
}