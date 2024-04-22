using CSE6581.Hotel.ATR.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Controllers
{
    public class RoomController : Controller
    {
        private IWebHostEnvironment host;
        
        public RoomController(IWebHostEnvironment host)
        {
            this.host = host;           
        }

        public async Task<IActionResult> Index(int page)
        {
            //Room room = new Room();
            //room.Price = 220;
            //room.Name = "Single Room";
            //room.Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";
            //room.PathImage = "img/room/5.jpg";
            //room.PathLargeImage = "img/room/l-5.jpg";

            //_db.Rooms.Add(room);
            //_db.SaveChanges();


            List<Room> listRooms = new List<Room>();
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient
                    .GetAsync("http://localhost:5161/api/Room"))
                {
                    var content = await responce
                        .Content.ReadAsStringAsync();

                    listRooms = JsonConvert
                        .DeserializeObject<List<Room>>(content);
                }
            }


           //ViewBag.Clients = _db.Сlients.ToList();

            return View(listRooms);
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public IActionResult RoomDetails(int id)
        {
            return View();
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
