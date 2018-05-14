using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Filters;
using CarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    //[Produces("application/json")]
    //[Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarRentalDBContext _carRentalDBContext;

        public CarsController(CarRentalDBContext carRentalDBContext)
        {
            _carRentalDBContext = carRentalDBContext;

            if (_carRentalDBContext.CarSet.Count() == 0)
            {
                _carRentalDBContext.CarSet.Add(new Car { Id = 1, BrandName = "DMC", ModelName = "Delorian", YearOfConstruction = 1975 });
                _carRentalDBContext.SaveChanges();
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //wird Formular vom selben Client geschickt
        public IActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _carRentalDBContext.Add(car);
                _carRentalDBContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public IActionResult Details(int? id)
        {

            if (id == null) return NotFound();
            Car car = _carRentalDBContext.CarSet.FirstOrDefault(c => c.Id == id);
            if (car == null) return NotFound();


            //remove
            //_carRentalDBContext.CarSet.Remove(car);
            //_carRentalDBContext.SaveChanges();


            //update
            //_carRentalDBContext.CarSet.Update(car);
            //_carRentalDBContext.SaveChanges();


            return View(car);
        }

        [CustomExceptionFilter]
        public IActionResult Index()
        {
            //try
            {
                throw new Exception("Computer says NO");
            }
            //catch (Exception)
            {
                return new StatusCodeResult(500);
            }

            //return View(_carRentalDBContext.CarSet.ToList());
        }

    }
}