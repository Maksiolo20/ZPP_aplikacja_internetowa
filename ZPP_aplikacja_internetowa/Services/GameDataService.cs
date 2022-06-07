using Microsoft.AspNetCore.Mvc;
using ZPP_aplikacja_internetowa.Controllers;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Models;

namespace ZPP_aplikacja_internetowa.Services
{
    public class GameDataService : IGameData
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthentication _authentication;
        private readonly ILogger<GameDataController> _logger;
        public GameDataService(ApplicationDbContext context, IAuthentication authentication, ILogger<GameDataController> logger)
        {
            _context = context;
            _authentication = authentication;
            _logger = logger;
            _logger.LogWarning($"users {context.Users.Count()}");
        }
        private void AddPlayer(List<string> playersIds,string PlayerEmail)
        {
            string Id = _context.Users.FirstOrDefault(r => r.Email == PlayerEmail).Id;
            playersIds.Add(Id);

        }
        public async Task<bool> Login([FromForm] UnityUser user)
        {
            _logger.LogInformation($"Tryin to log user: {user.Email}, pass: {user.Password}");
            var toLog = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            if (toLog is not null)
            {
                var result = await _authentication.Login(toLog, user.Password);
                return result;
            }
            return false;
        }
        public async Task<bool> RecieveStats([FromForm] UnityGameResult unityGameResult)
        {
            int prevGamesCount = _context.Games.Count();
            Game plyedGame = new() { GameStatusId = 2, MapId = unityGameResult.MapId };
            List<string> playersIds = new();
            if (unityGameResult.WinnersEmail != null && unityGameResult.LoserEmail != null)
            {             

                AddPlayer(playersIds, unityGameResult.WinnersEmail);
                AddPlayer(playersIds, unityGameResult.LoserEmail);
                plyedGame.WinnerId = _context.Users.FirstOrDefault(r => r.Email == unityGameResult.WinnersEmail).Id;
            }
            foreach (var item in playersIds)
            {
                var player = _context.Users.FirstOrDefault(r => r.Id == item);
                _context.GameUsers.Add(new GameUser { UserId = player.Id, GameId = plyedGame.GameId });
            }
            _context.Games.Add(plyedGame);
            _context.SaveChanges();
            if (_context.Games.Count() > prevGamesCount) return true;
            return false;
        }
    }
}
