using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Extension;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Controllers
{
    public class UserController : Controller
    {
        BaseService<UserModel, UserForm> userServices;

        public UserController(BaseService<UserModel, UserForm> userServices)
        {
            this.userServices = userServices;
        }

        public IActionResult Connect()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Connect(UserConnectionForm form)
        {
            UserModel user = userServices.Call("Connect", form);
            HttpContext.Session.Set("User",user);
            return RedirectToAction("Index","Home", new { area = "User"});
        }

        public IActionResult Disconnect()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home", new { area = ""});
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForm form)
        {
            UserModel user = userServices.Insert(form);
            HttpContext.Session.Set("User", user);
            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}
