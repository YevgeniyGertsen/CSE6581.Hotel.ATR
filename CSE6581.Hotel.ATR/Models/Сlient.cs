using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Models
{
    public class Сlient
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
        public string AltImage { get; set; }
        public string ImagePathHover { get; set; }
    }
}