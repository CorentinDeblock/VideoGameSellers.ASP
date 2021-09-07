using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Models.Form.ProcedureForm;
using Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Extension;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Models.Form.RelationForm;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Areas.User.Controllers
{
    [Area("User")]
    public class SaleController : Controller
    {
        private BaseService<SaleModel, SaleForm> Service;
        private BaseService<GameModel, GameForm> GService;
        private IWebHostEnvironment _hostEnvironment;
        public SaleController(BaseService<SaleModel, SaleForm> service, BaseService<GameModel, GameForm> GameService, IWebHostEnvironment hostEnvironment)
        {
            Service = service;
            GService = GameService;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Create()
        {
            ViewBag.GameList = GService.Get();
            SaleForm form = new SaleForm
            {
                ProviderId = HttpContext.Session.GetUser().Id
            };
            return View(form);
        }
        [HttpPost]
        public IActionResult Create(SaleForm saleForm)
        {
            SaleModel sale = Service.Insert(saleForm);
            string pictureUrl = Path.Combine(_hostEnvironment.WebRootPath, "Image", saleForm.Picture.FileName);
            using (Stream fileStream = new FileStream(pictureUrl, FileMode.Create))
            {
                saleForm.Picture.CopyTo(fileStream);
            }

            Service.Call("Picture", new
            {
                SaleId = sale.Id,
                Picture = saleForm.Picture.FileName
            });
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(Service.Get());
        }

        public IActionResult Single(int id)
        {
            return View(Service.Get(id));
        }
        public IActionResult PublishMessage(int id)
        {
            return View(new MessageSaleForm 
            { 
                SaleId = id,
                UserId = HttpContext.Session.GetUser().Id
            });
        }

        [HttpPost]
        public IActionResult PublishMessage(MessageSaleForm messageForm)
        {
            Service.Call("Message", messageForm);
            return RedirectToAction("Single", new { id = messageForm.SaleId });
        }

        public IActionResult Bid(int id, int price)
        {
            return View(new SaleBidForm
            {
                SaleId = id,
                UserId = HttpContext.Session.GetUser().Id,
                Price = price + 1
            });
        }

        [HttpPost]
        public IActionResult Bid(SaleBidForm form)
        {
            Service.Call("BidSale", form);
            return RedirectToAction("Single", new { id = form.SaleId });
        }
        public IActionResult Buy(int id)
        {
            Service.Call("BuySale", new SaleActionForm
            {
                SaleId = id,
                UserId = HttpContext.Session.GetUser().Id
            });   

            return RedirectToAction("Index");
        }

        public IActionResult ConfirmBid(int id)
        {
            Service.Call("ConfirmBid", new SaleActionForm
            {
                SaleId = id,
                UserId = HttpContext.Session.GetUser().Id
            });

            return RedirectToAction("Index");
        }
    }
}
