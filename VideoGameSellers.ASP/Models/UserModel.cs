using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameSellers.ASP.Models.Enum;

namespace VideoGameSellers.ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public GradeType Grade { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
