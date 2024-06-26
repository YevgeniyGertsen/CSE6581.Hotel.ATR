﻿using System;
using System.Collections.Generic;

namespace CSE6581.Hotel.Atr.WebApi.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Descriotion { get; set; } = null!;
        public decimal Price { get; set; }
        public string PathToImage { get; set; } = null!;
    }
}
