using Microsoft.AspNetCore.Mvc;

namespace ZPP_aplikacja_internetowa.Controllers
{
    public class GameDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
