using GameBox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameServices _gameServices;

        public HomeController(IGameServices gameServices)
        {
            _gameServices = gameServices;
        }

        public IActionResult Index(string searchValue)
        {
            if(string.IsNullOrEmpty(searchValue))
            {
                var games = _gameServices.GetGames();
                return View(games);
            }
            else
            {
                var game = _gameServices.GetGameByName(searchValue);
                return View(game);
            }
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
