using Microsoft.AspNetCore.Mvc;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Controllers
{
    public class HallOfFameController : Controller
    {
        private readonly ApplicationDbContext _context;
        public Game Model { get; set; }
        public HallOfFameController(ApplicationDbContext context)
        {
            _context = context;
            Model = new Game();
        }
        public IActionResult Index()
        {
            return View(Model);
        }
    }
}
