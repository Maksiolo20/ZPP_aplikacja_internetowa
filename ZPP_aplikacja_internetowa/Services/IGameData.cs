using Microsoft.AspNetCore.Mvc;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;
using ZPP_aplikacja_internetowa.Models;

namespace ZPP_aplikacja_internetowa.Services
{
    public interface IGameData
    {
        public Task<bool> Login([FromForm] UnityUser user);
        public Task<bool> RecieveStats([FromForm] UnityGameResult unityGameResult);
    }
}
