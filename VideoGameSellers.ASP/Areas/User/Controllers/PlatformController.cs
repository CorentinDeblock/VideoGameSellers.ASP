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
    public class PlatformController : Controller
    {
        BaseService<PlatformModel, PlatformForm> Service;

        public PlatformController(BaseService<PlatformModel, PlatformForm> service)
        {
            Service = service;
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
