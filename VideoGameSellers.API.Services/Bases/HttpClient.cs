using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameSellers.API.Services.Bases
{
    class HttpClient<Model> where Model : class, new()
    {
        private string _url;

        public HttpClient(string url)
        {
            _url = url;
        }

        public Model Get(int id)
        {
            return CreateRequest((content) => JsonConvert.DeserializeObject<Model>(content), id);
        }

        private Response CreateRequest<Response>(Func<string,Response> func, params object[] data) where Response : class, new()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage httpContent = httpClient.GetAsync(_url + string.Join('/',data)).Result;
                if (httpContent.IsSuccessStatusCode)
                    return func(httpContent.Content.ReadAsStringAsync().Result);
            }
            return null;
        }
    }
}
