using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Areas.User.Controllers
{
    [Area("User")]
    public class GameController : Controller
    {
        private BaseService<GameModel, GameForm> Service;

        public GameController(BaseService<GameModel, GameForm> services)
        {
            Service = services;
        }

        public IActionResult Index()
        {
            return View(Service.Get());
        }

        public IActionResult Single(int id)
        {
            return View(Service.Get(id));
        }
    }
}
