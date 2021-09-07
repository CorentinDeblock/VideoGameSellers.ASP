using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameSellers.API.Services
{
    class SaleRepository : BaseRepository<SaleModel>
    {
        public IEnumerable<SaleModel> Get()
        {
            throw new NotImplementedException();
        }

        public SaleModel Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
