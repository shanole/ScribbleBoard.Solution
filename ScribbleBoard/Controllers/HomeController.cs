using Microsoft.AspNetCore.Mvc;

namespace ScribbleBoard.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
