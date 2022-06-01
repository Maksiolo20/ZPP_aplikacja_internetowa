using Microsoft.AspNetCore.Mvc;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Controllers
{
    public class HallOfFameController : Controller
    {
        private readonly ApplicationDbContext _context;
        public List<Game> _game { get; set; }  = new List<Game>();
        public Game Model { get; set; }
        public HallOfFameController(ApplicationDbContext context)
        {
            _context = context;
            //if (_context.Games.Count() < 1)
            //{
            //    _context.Games.Add(new Game() 
            //    {
            //    GameId="1",
            //    GameStatusId=2,
            //    MapId=1,
            //    WinnerId=1,
            //    });
            //    _context.SaveChanges();
            //}
        }
        public IActionResult Index()
        {
            return View(_game);
        }
    }
}
