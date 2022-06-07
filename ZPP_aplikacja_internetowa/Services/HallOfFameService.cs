using Microsoft.EntityFrameworkCore;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Models;

namespace ZPP_aplikacja_internetowa.Services
{
    public class HallOfFameService : IHallOfFame
    {
        private readonly ApplicationDbContext _context;
        public HallOfFameService(ApplicationDbContext context)
        {
            _context = context;
        }
        private string GetUserName(string Id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == Id).UserName;
        }
        public List<HallOfFameViewModel> GetGames()
        {
            List<Game> games = _context.Games.Include(x => x.Map).Include(x => x.Players).Include(x=>x.GameStatuses).ToList();
            List<HallOfFameViewModel> model = new List<HallOfFameViewModel>();
            foreach (var item in games)
            {
                string map = item.Map.Name;
                string winnerName = GetUserName(item.WinnerId);
                string loserName = GetUserName(item.Players.FirstOrDefault(x => x.GameId == item.GameId && x.UserId != item.WinnerId).UserId);
                string gameStatusName = item.GameStatuses.StatusName;
                string date = item.Date.ToUniversalTime().ToString();
                model.Add(new HallOfFameViewModel(
                    map,
                    winnerName,
                    loserName,
                    gameStatusName,
                    date
                    ));
            }
            return model;
        }
    }
}
