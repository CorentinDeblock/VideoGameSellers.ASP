using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Enum;

namespace Models.Model
{
    public class SaleTransactionModel
    {
        public double Price { get; set; }
        public SaleTransactionType Type { get; set; }
        public SaleModel Sale { get; set; }
    }
}
