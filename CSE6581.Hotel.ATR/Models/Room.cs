using System;
using System.Collections.Generic;

#nullable disable

namespace CSE6581.Hotel.ATR.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriotion { get; set; }
        public decimal Price { get; set; }
        public string PathToImage { get; set; }
    }
}
