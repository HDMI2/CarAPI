using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using Microsoft.AspNetCore.Http;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            SetCookie("Car", "Düsseldorf 2018", 5);

            return View();
        }

        private void SetCookie(string key, string value, int? expireTime)
        {
            var options = new CookieOptions();
            if (expireTime.HasValue)
            {
                options.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            }
            else
            {
                options.Expires = DateTime.Now.AddMilliseconds(10);

            }

          //  var keks = Response.Cookies["Car"];
            Response.Cookies.Delete("Car");

            Response.Cookies.Append(key, value, options);
        }

        public IActionResult About()
        {
            TempData["Engine"] = "Schow Engine";
           // ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
