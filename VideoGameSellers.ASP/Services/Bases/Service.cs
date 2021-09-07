using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace VideoGameSellers.ASP.Services.Bases
{
    public abstract class Service<Model, Form> : BaseService<Model, Form> where Model : class, new()
    {
        private string _url;
        private string _endpoint;
        private HttpClient _client = new HttpClient();

        public Service(AppEnv appEnv)
        {
            _url = appEnv.ApiUrl;
            _client.BaseAddress = new Uri(_url);
            _endpoint = endpoint;
        }

        protected abstract string endpoint { get; }

        public Model Call<Data>(string endpoint, Data data)
        {
            return CreatePostRequest((content) => JsonConvert.DeserializeObject<Model>(content), data, endpoint);
        }

        public ReturnType CallGet<ReturnType>(params object[] data)
        {
            return CreateGetRequest((content) => JsonConvert.DeserializeObject<ReturnType>(content),data);
        }

        public IEnumerable<Model> Get()
        {
            return CreateGetRequest((content) => JsonConvert.DeserializeObject<IEnumerable<Model>>(content));
        }

        public Model Get(int id)
        {
            return CreateGetRequest((content) => JsonConvert.DeserializeObject<Model>(content), id);
        }

        public Model Insert(Form form)
        {
            return CreatePostRequest((content) => JsonConvert.DeserializeObject<Model>(content), form);
        }

        private Response CreateGetRequest<Response>(Func<string,Response> func, params object[] suburl)
        {
            string url = FormatUrl(suburl);
            HttpResponseMessage httpResponse = _client.GetAsync(url).Result;
            return ProcessRequest(func, httpResponse);
        }

        private Response CreatePostRequest<Data,Response>(Func<string, Response> func, Data data, params object[] suburl)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage httpResponse = _client.PostAsync(FormatUrl(suburl),content).Result;
            return ProcessRequest(func, httpResponse);
        }

        private Response ProcessRequest<Response>(Func<string,Response> func, HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return func(response.Content.ReadAsStringAsync().Result);
            throw new Exception(response.ReasonPhrase);
        }

        private string FormatUrl(params object[] suburl)
        {
            return _endpoint + (suburl.Length > 0 ? $"/{string.Join('/', suburl)}" : "");
        }
    }
}
