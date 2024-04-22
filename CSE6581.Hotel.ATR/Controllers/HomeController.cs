using CSE6581.Hotel.ATR.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSE6581.Hotel.ATR.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;    
        private IConfiguration _config;
        private IOptions<ApiEndpoint> _settings;

        public HomeController(ILogger<HomeController> logger,         
             IConfiguration config,
             IOptions<ApiEndpoint> settings)
        {
            _logger = logger;          
            _config = config;
            _settings = settings;
        }

        [TypeFilter(typeof(CustomExceptionFilter), Order = 2)]
        [TimeElapsed]
        public IActionResult Index(string culture = "")
        {
            var data0 = _settings.Value.Url;
            var data = 
                _config.GetSection("Middleware")
                .GetSection("EnableContentMiddleware")
                .Value;

            var data2 =
            _config.GetSection("Middleware")
            .GetValue<bool>("EnableContentMiddleware");


            var data3 = _config
                .GetSection("Middleware:EnableContentMiddleware")
                .Value;


            return View();
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
