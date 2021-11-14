using Microsoft.AspNetCore.Mvc;
using SuperHeroLab.Data.Interface;
using SuperHeroLab.Data.Model;

namespace SuperHeroLab.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            ViewBag.Message = "The page you are looking for was not found.";
            return View("_NotFound");
        }
    }
}
