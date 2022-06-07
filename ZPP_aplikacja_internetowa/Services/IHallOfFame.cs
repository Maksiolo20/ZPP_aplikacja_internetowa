using ZPP_aplikacja_internetowa.Models;

namespace ZPP_aplikacja_internetowa.Services
{
    public interface IHallOfFame
    {
        public List<HallOfFameViewModel> GetGames();
    }
}
