using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models;

namespace VideoGameSellers.ASP.Extension
{
    public static class SessionExt
    {
        public static void Set<Data>(this ISession session, string key, Data data)
        {
            session.SetString(key, JsonConvert.SerializeObject(data));
        }

        public static Data Get<Data>(this ISession session, string key) where Data : class, new()
        {
            string data = session.GetString(key);
            return data != null ? JsonConvert.DeserializeObject<Data>(session.GetString(key)) : null;
        }

        public static UserModel GetUser(this ISession session)
        {
            return Get<UserModel>(session, "User");
        }
        public static void SetUser(this ISession session,UserModel user)
        {
            Set(session, "User",user);
        }
    }
}
