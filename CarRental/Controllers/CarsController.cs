using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]")]
    public class CarsController : Controller
    {

        public IActionResult Index()
        {
            var cars = new List<Car>();
            cars.Add(new Car { Id = 1, BrandName = "DMC", ModelName = "Delorian", YearOfConstruction = 1975 });

            return View(cars);
        }

    }
}