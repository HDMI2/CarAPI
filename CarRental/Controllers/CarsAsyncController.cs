using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarsAsyncController : Controller
    {
        private readonly CarRentalDBContext _carRentalDBContext;

        public CarsAsyncController(CarRentalDBContext carRentalDBContext)
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
    public async Task<IActionResult> Create(Car car)
    {
        if (ModelState.IsValid)
        {
            await _carRentalDBContext.AddAsync(car);
            _carRentalDBContext.SaveChanges();
          return RedirectToAction(nameof(Index));
        }

        return View();
    }


    public async Task<IActionResult> Details(int? id)
    {

        if (id == null) return NotFound();
        Car car = await _carRentalDBContext.CarSet.FirstOrDefaultAsync(c => c.Id == id);
        if (car == null) return NotFound();


        return View(car);
    }
    }

}