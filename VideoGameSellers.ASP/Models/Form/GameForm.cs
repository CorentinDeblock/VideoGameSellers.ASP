﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameSellers.ASP.Models.Form
{
    public class GameForm
    {
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Appearance { get; set; }
    }
}
