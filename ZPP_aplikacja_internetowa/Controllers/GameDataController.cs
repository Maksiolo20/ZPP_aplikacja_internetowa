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

        [HttpPost]
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

        [HttpPost]
        public async Task<IActionResult> RecieveStats([FromForm] UnityGameResult unityGameResult)
        {
            //Game game = JsonSerializer.Deserialize<Game>(resultJson);
            var winner = _context.Users.FirstOrDefault(r => r.Email == unityGameResult.WinnersEmail);
            List<User> players = new List<User>();
            foreach (var item in unityGameResult.PlayersEmails)
            {
                var player = _context.Users.FirstOrDefault(r => r.Email == item);
                players.Add(player);
            }

/*            if (winner is not null)
            {
                Game game = new Game()
                {
                    MapId = unityGameResult.MapId,
                    WinnerId = winner.Id,
                    Players = players

                };
            }
            _context.Games.Add(game);
            await _context.SaveChangesAsync();*/

            return Ok();
        }
    }
}



