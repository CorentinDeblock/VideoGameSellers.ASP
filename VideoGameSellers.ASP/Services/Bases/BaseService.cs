using System;
using System.Collections.Generic;

namespace VideoGameSellers.ASP.Services.Bases
{
    public interface BaseService<Model,Form>
    {
        IEnumerable<Model> Get();
        Model Get(int id);
        Model Insert(Form form);
        Model Call<Data>(string endpoint, Data data);
        ReturnType CallGet<ReturnType>(params object[] data);
    }
}
