using System;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Services
{
    public class SaleService : Service<SaleModel, SaleForm>
    {
        public SaleService(AppEnv env) : base(env)
        {
        }

        protected override string endpoint => "Sale";
    }
}
