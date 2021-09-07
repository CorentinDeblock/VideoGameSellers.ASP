using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Extension;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        BaseService<UserModel, UserForm> Service;

        public HomeController(BaseService<UserModel, UserForm> service)
        {
            Service = service;
        }

        public IActionResult Index()
        {
            return View(Service.CallGet<IEnumerable<SaleTransactionModel>>("Historic", HttpContext.Session.Get<UserModel>("User").Id));
        }
    }
}
