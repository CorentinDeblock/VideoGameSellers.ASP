﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameSellers.ASP.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Appearance { get; set; }
        public PictureModel Picture { get; set; }
    }
}
