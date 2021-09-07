using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models.Enum;

namespace VideoGameSellers.ASP.Models.Form
{
    public class SaleForm
    {
        public int ProviderId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public SaleType Type { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public IFormFile Picture { get; set; }
    }
}
