using DojoSurvey.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public ViewResult Index()
        {
            return View("Index");
        }
        [HttpPost("result")]
        public ViewResult Result(Survey survey)
        {

            return View("Result", survey);
        }
    }
}