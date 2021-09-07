using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models;
using VideoGameSellers.ASP.Models.Form;
using VideoGameSellers.ASP.Services.Bases;

namespace VideoGameSellers.ASP.Services
{
    public class GameService : Service<GameModel, GameForm>
    {
        public GameService(AppEnv appEnv) : base(appEnv)
        {
        }

        protected override string endpoint => "Game";
    }
}
