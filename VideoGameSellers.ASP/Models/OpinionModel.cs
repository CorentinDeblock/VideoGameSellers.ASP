using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models.Enum;

namespace VideoGameSellers.ASP.Models
{
    public class OpinionModel
    {
        public int Id { get; set; }
        public OpinionType Type { get; set; }
        public DateTime PublishedAt { get; set; }

        public UserModel User { get; set; }
    }
}
