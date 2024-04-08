using CSE6581.Hotel.ATR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR
{
    public class HotelAtrContext : DbContext
    {
        public HotelAtrContext(DbContextOptions<HotelAtrContext> options) :base(options)
        {
          
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Сlient> Сlients { get; set; }
    }
}
