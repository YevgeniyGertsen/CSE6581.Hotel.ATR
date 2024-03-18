using CSE6581.Hotel.ATR.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

      
        [TimeElapsed]
        [CustomExceptionFilter]
        public IActionResult Index(string culture="")
        {
            //--
            GetCulture(culture);

            throw new Exception("Моя тестовая ошибка");

            #region old
            string key = "IIN";
            string value = "880111300392";

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);

            //Добавии куки набор
            Response.Cookies.Append(key, value, options);

            //получить куки набор
            var iin = Request.Cookies[key];

            //удалили куки набор
            //Response.Cookies.Delete(key);


            //Установили сессию, поместили значение в сессию
            HttpContext.Session.SetString("URL", "ok.kz");

            if (HttpContext.Session.GetString("URL") != null)
            {
                var url = HttpContext.Session.GetString("URL");
            }


            User user = new User();
            user.email = "ok@ok.kz";

            _logger.LogError("У пользователя {email} возникла ошибка {errorMessage} с кодом {errorCode}",
                user.email, "ОШИБКА", 666);

            _logger.LogDebug("LogDebug");
            _logger.LogWarning("LogWarning");
            #endregion

            //--

            //--
            return View();
            //--
        }

        public string GetCulture(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                CultureInfo.CurrentCulture = new CultureInfo(code);

                CultureInfo.CurrentUICulture = new CultureInfo(code);
            }
            return "";
        }


        //using Microsoft.AspNetCore.Authorization;
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            if (login == "admin" && password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login)
                };

                var climsIdentity = new ClaimsIdentity(claims, "Login");

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(climsIdentity));
            }

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
