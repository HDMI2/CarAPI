using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWebApi.Models;
using CarWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var cars = await _carRepository.GetAll();
            return (cars);
        }
        // GET: api/Car/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {

            return await _carRepository.FindByIdAsync(id);

        }


        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<Car>> Post([FromBody] Car car)
        {

            var res = await _carRepository.Update(car);

            return CreatedAtRoute("GetCar", new { id = car.Id }, car);
        }


        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Car car)
        {

            if (car.Id != id)
            {
                return BadRequest();

            }

            await _carRepository.Update(car);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var car = await _carRepository.FindByIdAsync(id);
            _carRepository.Remove(car);

            return new NoContentResult();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<Car>> Patch(int id, [FromBody] JsonPatchDocument<Car> patch)
        {
            var car = await _carRepository.FindByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            patch.ApplyTo(car, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _carRepository.SaveAll();
            return car;
        }

    }
}
