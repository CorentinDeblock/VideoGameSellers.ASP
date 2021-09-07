using System;
using System.Collections.Generic;

namespace VideoGameSellers.API.Services
{
    public interface BaseRepository<Model>
    {
        IEnumerable<Model> Get();
        Model Get(int id);
    }
}
