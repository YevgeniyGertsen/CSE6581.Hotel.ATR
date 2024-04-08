using CSE6581.Hotel.ATR.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment host;
        private HotelAtrContext _db;

        public RoomController(IWebHostEnvironment host, HotelAtrContext db)
        {
            this.host = host;
            _db = db;
        }

        public IActionResult Index(int page)
        {
            List<Room> listRooms = _db.Rooms.ToList();
            ViewBag.Clients = _db.Сlients.ToList();

            return View(listRooms);
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public IActionResult RoomDetails(int id)
        {
            var room = _db.Rooms.FirstOrDefault(f=>f.Id == id);
            return View(room);
        }


        //string email, string name
        //User user
        //var data = Request.Form;
        [HttpPost]
        public IActionResult Subcribes(IFormFile userFile)
            //Microsoft.AspNetCore.Http;
        {
            string path = Path.Combine(host.WebRootPath,
                "Files",
                userFile.FileName);
                
              
            using (var streame= new FileStream(path, FileMode.Create))
            {
                userFile.CopyTo(streame);
            }

            //return View("Index");
            //return View("~/Views/Home/Privacy.cshtml");
            return RedirectToAction("Index");
        }


        public string GetSomeText()
        {
            return "Text";
        }
    }
}
