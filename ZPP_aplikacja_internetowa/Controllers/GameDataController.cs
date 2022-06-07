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
        private readonly IGameData _gameData;

        public GameDataController(IGameData gameData)
        {
            _gameData = gameData;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] UnityUser user)
        {
            return await _gameData.Login(user) ? Ok() : BadRequest();
        }

        [HttpPost("GetWinner")]
        public async Task<IActionResult> RecieveStats([FromForm] UnityGameResult unityGameResult)
        {
            return await _gameData.RecieveStats(unityGameResult) ? Ok() : BadRequest();
        }
    }
}



