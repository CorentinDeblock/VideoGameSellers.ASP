using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameSellers.ASP.Services.Bases
{
    public class AppEnv
    {
        public AppEnv(string url) {
            ApiUrl = url;
        }

        public string ApiUrl { get; set; }

        public string Endpoint(string endpoint)
        {
            return $"{ApiUrl}{endpoint}";
        }
    }
}
