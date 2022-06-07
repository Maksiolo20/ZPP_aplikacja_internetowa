using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Controllers
{
    [ApiController]
    [Route("Api")]
    public class HallOfFameController : Controller
    {
        private readonly ApplicationDbContext _context;
       
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
        [HttpGet]
        public IActionResult Index()
        {

            List<Game> games = _context.Games.Include(x=>x.Map).Include(x=>x.Players).ToList();
            return View(games);
        }
    }
}
