using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Models;
using ZPP_aplikacja_internetowa.Services;

namespace ZPP_aplikacja_internetowa.Controllers
{
    [ApiController]
    [Route("Api")]
    public class HallOfFameController : Controller
    {
        private readonly IHallOfFame _hallOfFame;
        public HallOfFameController(IHallOfFame HallOfFame)
        {
            _hallOfFame = HallOfFame;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_hallOfFame.GetGames());
        }
    }
}
