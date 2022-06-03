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
            Game plyedGame = new() { GameStatusId = 2, MapId = unityGameResult.MapId };
            User winner = null;
            User looser = null;
            //Game game = JsonSerializer.Deserialize<Game>(resultJson);
            if (unityGameResult.WinnersEmail != null)
            {
                var emailSplit = unityGameResult.WinnersEmail.Split('\'');
                winner = _context.Users.FirstOrDefault(r => r.Email == emailSplit[1]);
                plyedGame.WinnerId = winner.Id;
            }
            if (unityGameResult.LoosersEmail != null)
            {
                //var emailSplit = unityGameResult.WinnersEmail.Split('\'');
                looser = _context.Users.FirstOrDefault(r => r.Email == unityGameResult.LoosersEmail);
                _logger.LogWarning(looser.Email);
                _logger.LogWarning(looser.Id);

            }

            if (winner is not null && looser is not null)
            {
                GameUser gameUser = new GameUser() { UserId = winner.Id, GameId = plyedGame.GameId };
                _context.GameUsers.Add(gameUser);
                gameUser = new GameUser() { UserId = looser.Id, GameId = plyedGame.GameId };
                _context.GameUsers.Add(gameUser);
                //_context.GameUsers.Add(new GameUser { UserId = winner.Id, GameId = plyedGame.GameId });
                //_context.GameUsers.Add(new GameUser { UserId = looser.Id, GameId = plyedGame.GameId });
            }

            _context.Games.Add(plyedGame);
            _context.SaveChanges();
            return Ok();
        }
    }
}



