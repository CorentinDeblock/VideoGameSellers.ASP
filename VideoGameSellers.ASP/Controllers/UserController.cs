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
            if(user != null)
            {
                HttpContext.Session.Set("User", user);
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            ViewData["Error"] = "Mauvais email ou mot de passe";
            form.Password = "";
            return View(form);
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
            if(user != null && form.Password == form.ConfirmPassword)
            {
                HttpContext.Session.Set("User", user);
                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            if(form.Password != form.ConfirmPassword)
                ViewData["Error"] = "Les mots de passe ne corresponde pas";
            else
                ViewData["Error"] = "L'email ou le nom d'utilisateur est deja utiliser ou bien l'email n'est pas valide";
            form.Password = "";
            form.ConfirmPassword = "";
            return View(form);
        }
    }
}
