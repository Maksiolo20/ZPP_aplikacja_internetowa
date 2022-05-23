using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Services;

namespace ZPP_aplikacja_internetowa.Controllers
{
    public class GameDataController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthentication _authentication;
        private readonly ILogger<GameDataController> _logger;

        public GameDataController(ApplicationDbContext context, IAuthentication authentication, ILogger<GameDataController> logger)
        {
            _context = context;
            _authentication = authentication;
            _logger = logger;
            _logger.LogWarning($"_context {_context.Users.Count()}");
            _logger.LogWarning($"context {context.Users.Count()}");
        }
        /*        [HttpPost]
                public IActionResult Index(string resultJson)
                {
                    Game game = JsonSerializer.Deserialize<Game>(resultJson);
                    _context.Games.Add(game);
                    _context.SaveChangesAsync();
                    return View();
                }*/

        [HttpGet]
        public int Index()
        {
            return 5;
        }

        [HttpPost]
        public IActionResult Login2([FromBody]UnityUser user)
        {
            return Ok();
        }


        public async Task<IActionResult> Login([FromBody]UnityUser user)
        {
            _logger.LogInformation($"Tryin to log user: {user.Email}, pass: {user.Password}");
            var toLog = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (toLog is not null)
            {
                var result = await _authentication.Login(toLog, user.Password);
                return Ok(result);
            }
            return BadRequest();
            //return Ok();
        }

        public IActionResult Login1([FromBody] UnityUser user)
        {
            var foundUser = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (foundUser is not null)
            {
                //TODO - naprawic porownanie hasla
                if (foundUser.PasswordHash == user.Password)
                {
                    //send confirmation
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
