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
        public RoomController(IWebHostEnvironment host)
        {
            this.host = host;
        }

        public IActionResult Index(int page)
        {
            //connect to db db.Users().ToList();

            ViewBag.Page = 666;

            User user = new User() { email="ok@ok.kz"};

            return View(user);
        }

        public IActionResult RoomList()
        {
            return View();
        }

        public IActionResult RoomDetails()
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
