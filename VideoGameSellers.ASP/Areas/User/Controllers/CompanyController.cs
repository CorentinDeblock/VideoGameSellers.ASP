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
    public class CompanyController : Controller
    {
        private BaseService<CompanyModel, CompanyForm> Service;

        public CompanyController(BaseService<CompanyModel, CompanyForm> services)
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
