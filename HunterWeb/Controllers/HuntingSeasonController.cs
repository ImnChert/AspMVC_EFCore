using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class HuntingSeasonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
