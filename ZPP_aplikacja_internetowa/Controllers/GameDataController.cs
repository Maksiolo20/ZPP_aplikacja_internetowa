using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Services;

namespace ZPP_aplikacja_internetowa.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UnityLoginService _unityLoginService;
        public GameDataController(ApplicationDbContext context, UnityLoginService unityLoginService)
        {
            _context = context;
            _unityLoginService = unityLoginService;
        }
        [HttpPost]
        public IActionResult Index(string resultJson)
        {
            Game game = JsonSerializer.Deserialize<Game>(resultJson);
            _context.Games.Add(game);
            _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost(Name = "GetUser")]
        public async Task<IActionResult> GetUser([FromBody] UnityUser unityUser)
        {
            if (await _unityLoginService.UserExists(unityUser) )return Ok();
            return BadRequest();
        }
    }
}
