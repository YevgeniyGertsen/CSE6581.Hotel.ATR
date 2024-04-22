using CSE6581.Hotel.Atr.WebApi.Data;
using CSE6581.Hotel.Atr.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSE6581.Hotel.Atr.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private HotelAtrContext _db;
        public RoomController(HotelAtrContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Room> Get()
        {
            var rooms = _db.Rooms;

            return rooms;
        }

        [HttpGet("GetAvaliableRoom")]
        public IEnumerable<Room> GetAvaliableRoom()
        {
            var rooms = _db.Rooms;

            return rooms;
        }

        [HttpGet("{Id}")]
        public Room Get(int Id)
        {
            var room = _db.Rooms.Find(Id);
            return room;
        }

        [HttpPost]
        public Room Post([FromBody] Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();

            return room;
        }

        [HttpPut]
        public StatusCodeResult Put([FromForm] Room room)
        {
            var data = _db.Rooms.Find(room.Id);

            if (data != null)
            {
                data.Price = room.Price;
                data.Name = room.Name;
                data.PathToImage = room.PathToImage;
                data.Descriotion = room.Descriotion;

                _db.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            var data = _db.Rooms.Find(Id);

            if (data != null)
            {
                _db.Rooms.Remove(data);
                _db.SaveChanges();  
            }
        }
    }
}
