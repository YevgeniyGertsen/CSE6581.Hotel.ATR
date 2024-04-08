using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        //Single Room
        [Required]
        public string Name { get; set; }

        //Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
        public string Description { get; set; }

        //$220
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }

        public int Floor { get; set; }

        //img/room/5.jpg
        public string PathImage { get; set; }
        public string PathLargeImage { get; set; }
    }
}
