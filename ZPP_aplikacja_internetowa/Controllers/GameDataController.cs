using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Controllers
{
    
    public class GameDataController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GameDataController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Index(string resultJson)
        {
            Game game = JsonSerializer.Deserialize<Game>(resultJson);
            _context.Games.Add(game);
            _context.SaveChangesAsync();
            return View();
        }
    }
}
