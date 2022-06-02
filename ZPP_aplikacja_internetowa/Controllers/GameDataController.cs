using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Services;
using AutoMapper;
using ZPP_aplikacja_internetowa.Models;

namespace ZPP_aplikacja_internetowa.Controllers
{
    [ApiController]
    [Route("Api")]
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
            _logger.LogWarning($"users {context.Users.Count()}");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UnityUser user)
        {
            _logger.LogInformation($"Tryin to log user: {user.Email}, pass: {user.Password}");
            var toLog = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (toLog is not null)
            {
                var result = await _authentication.Login(toLog, user.Password);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("GetWinner")]
        public async Task<IActionResult> RecieveStats([FromForm] UnityGameResult unityGameResult)
        {
            Game plyedGame = new() { GameStatusId = 2, MapId = unityGameResult.MapId};
            //Game game = JsonSerializer.Deserialize<Game>(resultJson);
            if (unityGameResult.WinnersEmail != null)
            {
                string winnerId = _context.Users.FirstOrDefault(r => r.Email == unityGameResult.WinnersEmail).Id;
                plyedGame.WinnerId = winnerId;
            }
            foreach (var item in unityGameResult.PlayersEmails)
            {
                var player = _context.Users.FirstOrDefault(r => r.Email == item);
                _context.GameUsers.Add(new GameUser { UserId = player.Id, GameId = plyedGame.GameId });
            }
            _context.Games.Add(plyedGame);
            _context.SaveChanges();
            return Ok();
        }
    }
}



