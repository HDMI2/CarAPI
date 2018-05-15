using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.Api.Models;

namespace Training.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : Controller
    {
        private readonly CarAPIContext _ctx;

        public CarsController(CarAPIContext ctx)
        {
            _ctx = ctx;
            if (_ctx.CarSet.Count() == 0)
            {
                _ctx.CarSet.Add(new Car { Id = 1, BrandName = BrandNames.DMC, ModelName = "Delorian", YearOfConstruction = 1975 });
                _ctx.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            //var cars = await _ctx.CarSet.ToListAsync();
            //return Ok(cars);

            return await _ctx.CarSet.ToListAsync();

        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {

            var car = await _ctx.CarSet.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }
            return car;

        }

        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {
            if (car == null) return BadRequest();
            await _ctx.CarSet.AddAsync(car);
            await _ctx.SaveChangesAsync();

            return CreatedAtRoute("GetCar", new { id = car.Id },car);
        }


        //Schließen der DB Verbindung
        ~CarsController()
        {
            Dispose();
        }

    }
}