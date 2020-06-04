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
        public ViewResult Result(string name, string location, string favLang, string comment)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.FavLang = favLang;
            ViewBag.Comment = comment;
            return View("Result");
        }
    }
}