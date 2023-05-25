using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
